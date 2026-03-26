using System.Drawing;

namespace ConsoleUi;

public class Container : IUiNode
{
    public List<IUiNode> Children { get; set; } = [];

    protected Rectangle _bounds =  Rectangle.Empty;
    
    public virtual void Render(Canvas canvas)
    {
        foreach (var child in Children)
        {
            child.Render(canvas);
        }
    }

    public virtual Size GetRenderSize(Size reserved)
    {
        var size = Size.Empty;
        
        foreach (var child in Children)
        {
            var childSize = child.GetRenderSize(reserved);
            size.Width += childSize.Width;
            size.Height = int.Max(size.Height, childSize.Height);
        }
        
        return size;
    }

    public virtual Rectangle GetRenderBounds(Rectangle reserved)
    {
        var renderSize = GetRenderSize(reserved.Size);
        _bounds = new Rectangle(reserved.Location, renderSize);
        
        var location = reserved.Location;
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