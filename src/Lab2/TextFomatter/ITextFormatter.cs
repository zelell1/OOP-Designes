using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;

public interface ITextFormatter : ITextFormatter
{
    Header FormatHeader(Header header);

    Body FormatBody(Body body);
}