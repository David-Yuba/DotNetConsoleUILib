class GraphicSymbols
{
    public static char TopLeftCorner = (char)9484;
    public static char TopRightCorner = (char)9488;
    public static char BotLeftCorner = (char)9492;
    public static char BotRightCorner = (char)9496;
    public static char VerticalLine = (char)9474;
    public static char HorizontalLine = (char)9472;
    public static char FilledSquare = (char)9617;
    public static char Space = (char)10;
    public static char Null = '\0';

    public static char GetScreenSymbol(int[] pos, int width, int height)
    {
        return pos switch
        {
            [0, 0] => GraphicSymbols.TopLeftCorner,
            [int x, 0] when x == (width - 2) => GraphicSymbols.TopRightCorner,
            [0, int x] when x == (height - 1) => GraphicSymbols.BotLeftCorner,
            [int x, int y] when (x == (width - 2)) && (y == (height - 1)) => GraphicSymbols.BotRightCorner,
            [int x, _] when x == 0 || x == (width - 2) => GraphicSymbols.VerticalLine,
            [int x, int y] when x == (width - 1) && y != (height - 1) => GraphicSymbols.Space,
            [int x, int y] when x == (width - 1) && y == (height - 1) => GraphicSymbols.Null,
            [_, int x] when x == 0 || x == (height - 1) => GraphicSymbols.HorizontalLine,
            _ => GraphicSymbols.FilledSquare,
        };
    }
}
