using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public interface ISection
{
    PassResult PassSection(Train train);
}