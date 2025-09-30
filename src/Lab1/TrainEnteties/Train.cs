using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

public class Train
{
    public PassengerFlow PassengerFlow { get; }

    public Speed Speed { get; private set; }

    private Mass Mass { get; }

    private TimeAccuracy TimeAccuracy { get; }

    private Force MaxForce { get; }

    private Boost Boost { get; set; }

    public Train(Mass massTrain, PassengerFlow passengerFlow, TimeAccuracy timeAccuracy, Force maxForce)
    {
        Speed = Speed.Zero();
        Mass = massTrain;
        TimeAccuracy = timeAccuracy;
        PassengerFlow = passengerFlow;
        MaxForce = maxForce;
        Boost = Boost.Zero();
    }

    public TraversalResult CalculateTime(SectionLength sectionLength, Force force)
    {
        if (force.Value > MaxForce.Value)
        {
            return new TraversalResult.Failure();
        }

        Boost = new Boost(force.Value / Mass.Value);
        var currLength = PassedDistance.Zero();
        Speed currentSpeed = Speed with { };
        var time = Time.Zero();
        while (currLength.Value < sectionLength.Value)
        {
            currentSpeed = new Speed(currentSpeed.Value + (Boost.Value * TimeAccuracy.Value));

            if (currentSpeed.Value <= 0)
            {
                return new TraversalResult.Failure();
            }

            currLength = new PassedDistance(currLength.Value + (currentSpeed.Value * TimeAccuracy.Value));
            time = new Time(TimeAccuracy.Value + time.Value);
        }

        Speed = currentSpeed with { };
        return new TraversalResult.Success(time);
    }
}