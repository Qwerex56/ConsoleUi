using System.Drawing;

namespace ConsoleUi;

public interface IUiNode
{
    public void Render(Canvas canvas);
    public Size GetRenderSize(Size reserved);
    public Rectangle GetRenderBounds(Rectangle reserved);
}