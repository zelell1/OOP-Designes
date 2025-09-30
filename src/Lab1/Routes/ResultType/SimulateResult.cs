using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.ResultType;

public abstract record SimulateResult
{
    private SimulateResult() { }

    public sealed record Success(Time TimeValue) : SimulateResult;

    public sealed record Failure : SimulateResult;
}