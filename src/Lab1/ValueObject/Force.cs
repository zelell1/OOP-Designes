namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Force : BasePhysicsObject<double>
{
    public Force(double forceValue) : base(forceValue) { }

    protected override void IsValid(double forceValue) { }
}