namespace Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;

public interface ITextFormatter
{
    string FormatHeader(string message);

    string FormatBody(string message);
}