using ConsoleUI;
using System.Text;

Window win = new Window();

win.DrawScreen();

win.AddTextToScreen("This is a string", 105, 15);

win.DrawScreen();
Console.ReadLine();