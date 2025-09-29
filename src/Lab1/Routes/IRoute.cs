using Itmo.ObjectOrientedProgramming.Lab1.Routes.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRoute
{
    IReadOnlyCollection<ISection> Sections { get; }

    Speed MaxSpeed { get; }

    SimulateResult Simulate(ITrain train);
}