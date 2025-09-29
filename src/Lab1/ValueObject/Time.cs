namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Time : BasePhysicsObject<double>
{
    public Time(double timeValue) : base(timeValue) { }

    protected override void IsValid(double timeValue) { }
}