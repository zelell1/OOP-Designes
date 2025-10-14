using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;

public interface ITextFormatter
{
    Header FormatHeader(Message message);

    Body FormatBody(Message message);
}