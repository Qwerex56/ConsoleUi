namespace ConsoleUi.Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        var canvas = new Canvas(
            Console.WindowWidth,
            Console.WindowHeight);
        
        var root = new Container();
        root.Children.Add(new TextLine("hello world"));
        root.Children.Add(new MarginContainer
        {
            Children = [
                new TextLine("Hello from margin")
            ],
            MarginTop = 4,
            MarginLeft = 2,
            MarginRight = 2,
        });
        root.Children.Add(new TextLine("HELLO WORLD"));

        canvas.Clear();
        canvas.WriteToConsole();
        
        root.GetRenderBounds(canvas.Rectangle);
        root.Render(canvas);
        
        canvas.WriteToConsole();
    }
}