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

    public PassResult PassSection(ITrain train)
    {
        TraversalResult result = train.CalculateTime(_sectionLength, new Force(0));
        if (result is TraversalResult.Succes successResult)
        {
            return new PassResult.Succes(successResult.TimeValue);
        }

        return new PassResult.Failure();
    }
}