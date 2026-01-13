using ConsoleUI;
using System.Text;

Window win = new Window();

win.DrawScreen();

win.AddTextToScreen("This is a string", 5, 14);

win.DrawScreen();

while (true)
{
    ConsoleKeyInfo input = Console.ReadKey(true);
    if (input.Key == ConsoleKey.Escape) break;
    if (input.Key == ConsoleKey.J) Console.CursorTop++;
    if (input.Key == ConsoleKey.K) Console.CursorLeft++;
    if (input.Key == ConsoleKey.L) Console.CursorLeft--;
    if (input.Key == ConsoleKey.H) Console.CursorTop--;
    if (input.Key == ConsoleKey.I) Console.ReadLine();
    // win.DrawScreen();
}
