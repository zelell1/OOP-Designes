using Itmo.ObjectOrientedProgramming.Lab1.Routes.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private readonly IReadOnlyCollection<ISection> _sections;

    private readonly Speed _maxSpeed;

    public Route(IReadOnlyCollection<ISection> sections, Speed maxSpeed)
    {
        _sections = sections;
        _maxSpeed = maxSpeed;
    }

    public SimulateResult Simulate(Train train)
    {
        var routeTime = Time.Zero();
        foreach (ISection section in _sections)
        {
            PassResult result = section.PassSection(train);
            if (result is not PassResult.Success successResult)
            {
                return new SimulateResult.Failure();
            }

            routeTime = new Time(successResult.TimeValue.Value + routeTime.Value);
        }

        return train.Speed.Value > _maxSpeed.Value ? new SimulateResult.Failure() : new SimulateResult.Success(routeTime);
    }
}