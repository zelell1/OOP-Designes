namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

public abstract record ArgumentParseResult
{
    private ArgumentParseResult() { }

    public record Success : ArgumentParseResult { }

    public record NotFound : ArgumentParseResult { }

    public record Failure(string Error) : ArgumentParseResult { }
}