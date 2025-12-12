using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public record ConventionalMagneticPath : ISection
{
    private readonly SectionLength _sectionLength;

    public ConventionalMagneticPath(SectionLength sectionLength)
    {
        _sectionLength = sectionLength;
    }

    public PassResult PassSection(Train train)
    {
        TraversalResult result = train.CalculateTime(_sectionLength);

        if (result is TraversalResult.Success successResult)
        {
            return new PassResult.Success(successResult.TimeValue);
        }

        return new PassResult.Failure();
    }
}