using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainEnteties.ResultType;

public abstract record TraversalResult
{
    private TraversalResult() { }

    public sealed record Succes(Time TimeValue) : TraversalResult;

    public sealed record Failure : TraversalResult;
}