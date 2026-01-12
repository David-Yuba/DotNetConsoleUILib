namespace ConsoleUI;
public class Window
{
    Screen screen;
    Cursor cursor { get; }
    public Window()
    {
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
        int bufferLength = 0;
        for (int j=0; j<height; j++)
            for(int i=0; i<width; i++)
            {
                if (i == 0 && j == 0) buffer[i, j] = (char)9484;
                else if (i == (width - 2) && j == 0) buffer[i, j] = (char)9488;
                else if (i == 0 && j == (height - 1)) buffer[i, j] = (char)9492;
                else if (i == (width - 2) && j == (height - 1)) buffer[i, j] = (char)9496;
                else if (i == 0 || i == (width - 2)) buffer[i, j] = (char)9474;
                else if (i == (width - 1) && j != (height - 1)) buffer[i, j] = (char)10;
                else if (i == (width - 1) && j == (height - 1)) buffer[i, j] = '\0';
                else if (j == 0 || j == (height - 1)) buffer[i, j] = (char)9472;
                else buffer[i, j] = (char)9617;
                bufferLength++;
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