using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

public class Train : ITrain
{
    public Speed Speed { get; private set; }

    public Mass Mass { get; }

    public TimeAccuraccy TimeAccuracy { get; }

    public PassengerFlow PassengerFlow { get; }

    private Force MaxForce { get; }

    private Boost Boost { get; set; }

    public Train(Mass massTrain, PassengerFlow passengerFlow, TimeAccuraccy timeAccuracy, Force maxForce)
    {
        Speed = new Speed(0);
        Mass = massTrain;
        TimeAccuracy = timeAccuracy;
        PassengerFlow = passengerFlow;
        MaxForce = maxForce;
        Boost = new Boost(0);
    }

    public TraversalResult CalculateTime(SectionLength sectionLength, Force force)
    {
        if (force > MaxForce)
        {
            return new TraversalResult.Failure();
        }

        Boost = new Boost(force.ValueT / Mass.ValueT);
        var currLength = new PassedDistance(0);
        Speed currentSpeed = Speed with { };
        var time = new Time(0);
        while (currLength.ValueT < sectionLength.ValueT)
        {
            currentSpeed = new Speed(currentSpeed.ValueT + (Boost.ValueT * TimeAccuracy.ValueT));

            if (currentSpeed.ValueT <= 0)
            {
                return new TraversalResult.Failure();
            }

            currLength = new PassedDistance(currLength.ValueT + (currentSpeed.ValueT * TimeAccuracy.ValueT));
            time = new Time(TimeAccuracy.ValueT + time.ValueT);
        }

        Speed = currentSpeed with { };
        return new TraversalResult.Succes(time);
    }
}