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
        // Console.CursorLeft = cursor.GetPosition()[0];
        // Console.CursorTop = cursor.GetPosition()[1];
    }
    public void AddTextToScreen(string text, int posX, int posY)
    {
        screen.AddTextToScreen(text, posX, posY);
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
    char[,] buffer = new char[250,250];
    int width { get; set; }
    int height { get; set; }
    public Screen(int w, int h)
    {
        width = w;
        height = h;
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                buffer[i,j] = (char)176;
        SetScreenArea();
    }
    public void SetScreenArea()
    {
        for (int j=0; j<height; j++)
            for(int i=0; i<width; i++)
            {
                buffer[i, j] = GraphicSymbols.GetScreenSymbol([i, j], width, height);
            }
    }
    public void DrawScreen()
    {
        for (int j = 0; j < height; j++)
            for (int i = 0; i < width; i++)
                Console.Write(buffer[i, j]);
    }
    public void AddTextToScreen(string text, int posX, int posY)
    {
        int i, j, textIndex=0;
        for(j=posY; j<height; j++)
            for(i=posX; textIndex<text.Length; i++)
            {
                if (i == width - 2) break; 
                buffer[i, j] = text[textIndex++];
                if (textIndex == (text.Length)) return;
            }
    }
}