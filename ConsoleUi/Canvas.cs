using System.Drawing;

namespace ConsoleUi;

public class Canvas(int width, int height)
{
    private char[,] _buffer = new char[height, width];
    
    public Size Size => new(width, height);
    public Rectangle Rectangle => new(Point.Empty, Size);

    public void WriteToBuffer(int x, int y, char c)
    {
        _buffer[y, x] = c;
    }

    public void WriteToConsole()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < _buffer.GetLength(0); y++)
        {
            for (int x = 0; x < _buffer.GetLength(1); x++)
            {
                Console.Write(_buffer[y, x]);
            }
            
            Console.WriteLine();
        }
    }

    public void Clear()
    {
        for (var y = 0; y < _buffer.GetLength(0); y++)
        {
            for (var x = 0; x < _buffer.GetLength(1); x++)
            {
                _buffer[y, x] = ' ';
            }
        }
    }
}