public class GraphicSymbols
{
    public static (char thin, char bold) TopLeftCorner = (thin: (char)0x250C, bold: (char)0x250F);
    public static (char thin, char bold) TopRightCorner = (thin: (char)0x2510, bold: (char)0x2513);
    public static (char thin, char bold) BotLeftCorner = (thin: (char)0x2514, bold: (char)0x2517);
    public static (char thin, char bold) BotRightCorner = (thin: (char)0x2518, bold: (char)0x251B);
    public static (char thin, char bold) VerticalLine = (thin: (char)0x2502, bold: (char)0x2503);
    public static (char thin, char bold) HorizontalLine = (thin: (char)0x2500, bold: (char)0x2501);
    public static char FilledSquare = (char)0x2593;
    public static char Space = (char)' ';
    public static char Null = '\0';

    public static char GetScreenSymbol(int[] pos, int width, int height)
    {
        return pos switch
        {
            [0, 0] => GraphicSymbols.TopLeftCorner.bold,
            [int x, 0] when x == (width - 2) => GraphicSymbols.TopRightCorner.bold,
            [0, int x] when x == (height - 1) => GraphicSymbols.BotLeftCorner.bold,
            [int x, int y] when (x == (width - 2)) && (y == (height - 1)) => GraphicSymbols.BotRightCorner.bold,
            [int x, _] when x == 0 || x == (width - 2) => GraphicSymbols.VerticalLine.bold,
            [int x, int y] when x == (width - 1) && y != (height - 1) => GraphicSymbols.Space,
            [int x, int y] when x == (width - 1) && y == (height - 1) => GraphicSymbols.Null,
            [_, int x] when x == 0 || x == (height - 1) => GraphicSymbols.HorizontalLine.bold,
            _ => GraphicSymbols.FilledSquare,
        };
    }
}
