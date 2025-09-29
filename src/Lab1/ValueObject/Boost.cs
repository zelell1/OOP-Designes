namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Boost : BasePhysicsObject<double>
{
    public Boost(double boostValue) : base(boostValue) { }

    protected override void IsValid(double boostValue) { }
}