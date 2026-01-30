namespace Itmo.ObjectOrientedProgramming.Lab2.Logger;

public class TimeAndMessageLogger : ILogger
{
    private readonly Dictionary<DateTime, string> _logs;

    public TimeAndMessageLogger()
    {
        _logs = new Dictionary<DateTime, string>();
    }

    public void Log(string text)
    {
        _logs.Add(DateTime.Now, text);
    }
}