using System.Drawing;

namespace ConsoleUi;

public class MarginContainer : Container
{
    public int MarginTop { get; set; }
    public int MarginBottom { get; set; }
    public int MarginLeft { get; set; }
    public int MarginRight { get; set; }

    public sealed override Size GetRenderSize(Size reserved)
    {
        var size = base.GetRenderSize(reserved);

        size.Width += MarginLeft + MarginRight;
        size.Height += MarginTop + MarginBottom;
        
        return size;
    }
    
    public sealed override Rectangle GetRenderBounds(Rectangle reserved)
    {
        var renderSize = GetRenderSize(reserved.Size);
        _bounds = new Rectangle(reserved.Location, renderSize);
        
        var location = reserved.Location;
        
        location.Y += MarginTop;
        location.X += MarginLeft;
        
        var size = renderSize;
        
        foreach (var child in Children)
        {
            var childBound = child.GetRenderBounds(new Rectangle(location, size));
            
            location.X += childBound.Width;
            size.Width -= childBound.Width;
        }
        
        return _bounds;
    }
}