using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections.ResultType;

public abstract record PassResult
{
    private PassResult() { }

    public sealed record Succes(Time TimeValue) : PassResult;

    public sealed record Failure : PassResult;
}