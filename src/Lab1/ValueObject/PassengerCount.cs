namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record PassengerCount : BasePhysicsObject<int>
{
    public PassengerCount(int value) : base(value) { }

    protected override void IsValid(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(value.ToString());
        }
    }
}