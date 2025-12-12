namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record SectionLength
{
    public double Value { get; }

    public SectionLength(double sectionLengthValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sectionLengthValue);
        Value = sectionLengthValue;
    }
}