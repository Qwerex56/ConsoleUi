using System.Drawing;

namespace ConsoleUi;

public class TextLine(string text = "") : IUiNode
{
    private Rectangle _bounds = Rectangle.Empty;
    
    public void Render(Canvas canvas)
    {
        var posY = _bounds.Y;
        var posX = _bounds.X;
        
        foreach (var ch in text)
        {
            canvas.WriteToBuffer(posX, posY, ch);
            
            posX += 1;
        }
    }

    public Size GetRenderSize(Size reserved)
    {
        return new Size(text.Length, 1);
    }

    public Rectangle GetRenderBounds(Rectangle reserved)
    {
        var renderSize = GetRenderSize(reserved.Size);
        _bounds = new Rectangle(reserved.Location, renderSize);
        
        return _bounds;
    }
}