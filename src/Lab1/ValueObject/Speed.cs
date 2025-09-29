namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Speed : BasePhysicsObject<double>
{
    public Speed(double speedValue) : base(speedValue) { }

    protected override void IsValid(double speedValue) { }
}
