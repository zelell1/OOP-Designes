using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

public class Train
{
    private readonly Mass _mass;

    private readonly TimeAccuracy _timeAccuracy;

    private readonly Force _maxForce;

    private Boost _boost;

    public PassengerFlow PassengerFlow { get; }

    public Speed Speed { get; private set; }

    public Train(Mass massTrain, PassengerFlow passengerFlow, TimeAccuracy timeAccuracy, Force maxForce)
    {
        _mass = massTrain;
        _timeAccuracy = timeAccuracy;
        _maxForce = maxForce;
        _boost = Boost.Zero();
        PassengerFlow = passengerFlow;
        Speed = Speed.Zero();
    }

    public bool TrySetBoost(Force force)
    {
        if (force.Value > _maxForce.Value)
        {
            return false;
        }

        _boost = new Boost(force.Value / _mass.Value);

        return true;
    }

    public TraversalResult CalculateTime(SectionLength sectionLength)
    {
        var currLength = PassedDistance.Zero();
        Speed currentSpeed = Speed with { };
        var time = Time.Zero();

        while (currLength.Value < sectionLength.Value)
        {
            currentSpeed = new Speed(currentSpeed.Value + (_boost.Value * _timeAccuracy.Value));

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