namespace Lab5.Domain.Accounts.ResultType;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success : WithdrawResult { }

    public sealed record Failure : WithdrawResult { }
}