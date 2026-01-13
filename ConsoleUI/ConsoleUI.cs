using System.Security.Cryptography;
using System.Text;

namespace ConsoleUI;
public class Window
{
    Screen screen;
    Cursor cursor { get; }
    public Window()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        cursor = new Cursor();
        screen = new Screen(Console.BufferWidth, Console.BufferHeight);
    }
    public void DrawScreen()
    {
        Console.Clear();
        screen.DrawScreen();
    }
    public void AddTextToScreen(string text, int posX, int posY)
    {
        screen.AddTextToScreen(text, posX, posY);
    }
    public void GameLoop()
    {
        while (true)
        {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) break;
                if (input.Key == ConsoleKey.J && Console.CursorTop < screen.Height - 1) Console.CursorTop++;
                if (input.Key == ConsoleKey.K && Console.CursorLeft < screen.Width - 1) Console.CursorLeft++;
                if (input.Key == ConsoleKey.L && Console.CursorLeft > 0) Console.CursorLeft--;
                if (input.Key == ConsoleKey.H && Console.CursorTop > 0) Console.CursorTop--;
                if (input.Key == ConsoleKey.I) Console.ReadLine();
            }
            if (Console.BufferHeight != screen.Height || Console.BufferWidth != screen.Width)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                screen.Height = Console.BufferHeight;
                screen.Width = Console.BufferWidth;

                foreach(var element in screen.ElementList)
                {
                    element.ResizeWidth(screen.Width - screen.Padding * 2 - 2);
                }

                screen.SetScreenArea();
                screen.SetChildElements();
                DrawScreen();
            }
        }
    }
}

class Cursor
{
    int posX { get; set; }
    int posY { get; set; }

    public Cursor()
    {
        posX = 0;
        posY = 0;
    }
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
    public int[] GetPosition()
    {
        return [posX, posY];
    }
}
class Screen
{
    int Gap;
    public int Padding;
    public List<ReceiptInputElement> ElementList = new List<ReceiptInputElement>();
    char[,] buffer = new char[250, 250];
    public int Width { get; set; }
    public int Height { get; set; }
    public Screen(int w, int h)
    {
        Width = w;
        Height = h;
        Padding = 2;
        Gap = 1;
        AddChildElement(1,4);
        AddChildElement(1,4);
        AddChildElement(1,4);
        AddChildElement(1,4);
        AddChildElement(1,4);

        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                buffer[i,j] = (char)176;
        SetScreenArea();
        SetChildElements();
    }
    public void SetScreenArea()
    {
        for (int j=0; j<Height; j++)
            for(int i=0; i<Width; i++)
            {
                buffer[i, j] = GraphicSymbols.GetScreenSymbol([i, j], Width, Height);
            }
    }
    public void SetChildElements()
    {
        foreach (var element in ElementList)
        {
            element.DrawElement(ref buffer);
        }
    }
    public void DrawScreen()
    {
        for (int j = 0; j < Height; j++)
            for (int i = 0; i < Width; i++)
                Console.Write(buffer[i, j]);
    }
    public void AddTextToScreen(string text, int posX, int posY)
    {
        int i, j, textIndex=0;
        for(j=posY; j<Height; j++)
            for(i=posX; textIndex<text.Length; i++)
            {
                if (i == Width - 2) break; 
                buffer[i, j] = text[textIndex++];
                if (textIndex == (text.Length)) return;
            }
    }
    public void AddChildElement(int type, int height)
    {
        ReceiptInputElement newElement;
        if (ElementList.Count == 0)
            newElement = new ReceiptInputElement(height, Width - Padding*2 - 2, (Padding+1, Padding+1));
        else
        {
            var previousElementPos = ElementList.Last();
            (int x, int y) prevElPos = (previousElementPos.StartPoint.x, previousElementPos.EndPoint.y);
            newElement = new ReceiptInputElement(height, Width - Padding * 2 - 2, (Padding+1, Gap + prevElPos.y));
        }
        ElementList.Add(newElement);
    }
}