using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

public interface ITrain
{
    Mass Mass { get; }

    Speed Speed { get; }

    TimeAccuraccy TimeAccuracy { get; }

    PassengerFlow PassengerFlow { get; }

    TraversalResult CalculateTime(SectionLength sectionLength, Force force);
}