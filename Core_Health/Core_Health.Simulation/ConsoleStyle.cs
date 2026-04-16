namespace Core_Health.Simulation;

public static class ConsoleStyle
{
    public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
    {
        var previous = Console.ForegroundColor;

        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = previous;
    }
}