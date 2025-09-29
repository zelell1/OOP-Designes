using Itmo.ObjectOrientedProgramming.Lab1.Routes.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;
using System.Collections.Immutable;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route : IRoute
{
    public IReadOnlyCollection<ISection> Sections { get; }

    public Speed MaxSpeed { get; }

    public Route(IReadOnlyCollection<ISection> sections, Speed maxSpeed)
    {
        Sections = sections.ToImmutableList();
        MaxSpeed = maxSpeed;
    }

    public SimulateResult Simulate(ITrain train)
    {
        var routeTime = new Time(0);
        foreach (ISection section in Sections)
        {
            PassResult result = section.PassSection(train);
            if (result is PassResult.Succes successResul)
            {
                routeTime = new Time(successResul.TimeValue.ValueT + routeTime.ValueT);
            }
            else
            {
                return new SimulateResult.Failure();
            }
        }

        if (train.Speed > MaxSpeed)
        {
            return new SimulateResult.Failure();
        }

        return new SimulateResult.Succes(routeTime);
    }
}