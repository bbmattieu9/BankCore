namespace BankCore;

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }
    
    public void LogWarning(string message)
    {
        Console.WriteLine($"[WARNING] {message}");
    }
    
    public void LogSuccess(string message)
    {
        Console.WriteLine($"[SUCCESS] {message}");
    }
}