namespace Itmo.ObjectOrientedProgramming.Lab2.TextFomatter.TextFormatterEnteties;

public class MdFormatter : ITextFormatter
{
    public string FormatHeader(string message)
    {
        return new string($"# {message}{Environment.NewLine}");
    }

    public string FormatBody(string message)
    {
        return new string($"{message}{Environment.NewLine}");
    }
}