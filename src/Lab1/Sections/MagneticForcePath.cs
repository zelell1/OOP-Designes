using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public record MagneticForcePath : ISection
{
    private readonly SectionLength _sectionLength;
    private readonly Force _forceOnTrain;

    public MagneticForcePath(SectionLength sectionLength, Force forceOnTrain)
    {
        _sectionLength = sectionLength;
        _forceOnTrain = forceOnTrain;
    }

    public PassResult PassSection(Train train)
    {
        TraversalResult boostResult = train.CalculateBoost(_forceOnTrain);
        if (boostResult is TraversalResult.Failure)
        {
            return new PassResult.Failure();
        }

        TraversalResult result = train.CalculateTime(_sectionLength);
        train.CalculateBoost(Force.Zero());
        if (result is TraversalResult.Success successResult)
        {
            return new PassResult.Success(successResult.TimeValue);
        }

        return new PassResult.Failure();
    }
}