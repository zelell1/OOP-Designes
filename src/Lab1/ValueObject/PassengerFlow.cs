namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record PassengerFlow : BasePhysicsObject<int>
{
    public PassengerFlow(int valueFlow) : base(valueFlow) { }

    protected override void IsValid(int valueFlow)
    {
        if (valueFlow <= 0)
        {
            throw new ArgumentOutOfRangeException(valueFlow.ToString());
        }
    }
}