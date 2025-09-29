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

    public PassResult PassSection(ITrain train)
    {
        TraversalResult result = train.CalculateTime(_sectionLength, _forceOnTrain);
        if (result is TraversalResult.Succes successResult)
        {
            return new PassResult.Succes(successResult.TimeValue);
        }

        return new PassResult.Failure();
    }
}