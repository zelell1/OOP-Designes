using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Logger;

public class TimeAndMessageLogger : ILogger
{
    private readonly Collection<(string Message, DateTime Time)> _logs;

    public TimeAndMessageLogger()
    {
        _logs = new Collection<(string, DateTime)>();
    }

    public void Log(string text)
    {
        _logs.Add((text, DateTime.Now));
    }
}