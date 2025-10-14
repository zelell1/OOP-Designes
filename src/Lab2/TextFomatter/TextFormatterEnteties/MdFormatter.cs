using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.TextFomatter.TextFormatterEnteties;

public class MdFormatter : ITextFormatter
{
    public Header FormatHeader(Message message)
    {
        return new Header($"# {message.Header}{Environment.NewLine}");
    }

    public Body FormatBody(Message message)
    {
        return new Body($"{message.Body}{Environment.NewLine}");
    }
}