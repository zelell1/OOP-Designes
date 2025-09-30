using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

public class Train
{
    public PassengerFlow PassengerFlow { get; }

    public Speed Speed { get; private set; }

    private readonly Mass _mass;

    private readonly TimeAccuracy _timeAccuracy;

    private readonly Force _maxForce;

    private Boost Boost { get; set; }

    public Train(Mass massTrain, PassengerFlow passengerFlow, TimeAccuracy timeAccuracy, Force maxForce)
    {
        Speed = Speed.Zero();
        _mass = massTrain;
        _timeAccuracy = timeAccuracy;
        PassengerFlow = passengerFlow;
        _maxForce = maxForce;
        Boost = Boost.Zero();
    }

    public TraversalResult CalculateBoost(Force force)
    {
        if (force.Value > _maxForce.Value)
        {
            return new TraversalResult.Failure();
        }

        Boost = new Boost(force.Value / _mass.Value);
        return new TraversalResult.Success(Time.Zero());
    }

    public TraversalResult CalculateTime(SectionLength sectionLength)
    {
        var currLength = PassedDistance.Zero();
        Speed currentSpeed = Speed with { };
        var time = Time.Zero();
        while (currLength.Value < sectionLength.Value)
        {
            currentSpeed = new Speed(currentSpeed.Value + (Boost.Value * _timeAccuracy.Value));

            if (currentSpeed.Value <= 0)
            {
                return new TraversalResult.Failure();
            }

            currLength = new PassedDistance(currLength.Value + (currentSpeed.Value * _timeAccuracy.Value));
            time = new Time(_timeAccuracy.Value + time.Value);
        }

        Speed = currentSpeed with { };
        return new TraversalResult.Success(time);
    }
}