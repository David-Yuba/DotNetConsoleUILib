namespace ConsoleUI;
internal class ReceiptInputElement: UIElement
{
    public ReceiptInputElement(int height, int width, (int x, int y) pos)
    {
        InitElement(height, width, pos);
        EndPoint = (pos.x + width, pos.y + height);
    }
    public void DrawElement(ref char[,] buffer)
    {
        for (int j=StartPoint.y; j<EndPoint.y; j++)
        {
            for (int i=StartPoint.x; i<EndPoint.x-1; i++)
            {
                buffer[i, j] = GraphicSymbols.GetElementSymbol([i, j], StartPoint, Width, Height);
            }
            if (j == EndPoint.y - 1) break;
        }
    }
}
