using ConsoleUI;
using System.Text;

Window win = new Window();

win.DrawScreen();

win.AddTextToScreen("This is a string", 5, 14);

win.GameLoop();

