namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record TimeAccuraccy : BasePhysicsObject<double>
{
    public TimeAccuraccy(double timeAccuracyValue) : base(timeAccuracyValue) { }

    protected override void IsValid(double timeAccuracyValue)
    {
        if (timeAccuracyValue <= 0)
        {
            throw new ArgumentOutOfRangeException(timeAccuracyValue.ToString());
        }
    }
}