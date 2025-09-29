namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Mass : BasePhysicsObject<double>
{
    public Mass(double massValue) : base(massValue) { }

    protected override void IsValid(double massValue)
    {
        if (massValue <= 0)
        {
            throw new ArgumentOutOfRangeException(massValue.ToString());
        }
    }
}