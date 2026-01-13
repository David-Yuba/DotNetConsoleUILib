namespace ConsoleUI;
internal class UIElement
{
    public int Height;
    public int Width;
    public (int x, int y) StartPoint;
    public (int x, int y) EndPoint;

    public void InitElement(int height, int width, (int x, int y)pos)
    {
        Height = height;
        Width = width;
        StartPoint = pos;
    }
    void PositionElement(int x, int y)
    {
        StartPoint = (x, y);
    }
}
