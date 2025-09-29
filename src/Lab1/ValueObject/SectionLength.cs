namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record SectionLength : BasePhysicsObject<double>
{
    public SectionLength(double sectionLengthValue) : base(sectionLengthValue) { }

    protected override void IsValid(double sectionLengthValue)
    {
        if (sectionLengthValue <= 0)
        {
            throw new ArgumentOutOfRangeException(sectionLengthValue.ToString());
        }
    }
}