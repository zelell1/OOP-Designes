namespace Lab5.Domain.Operations.OperationTypes;

public abstract record OperationType
{
    private OperationType() { }

    public sealed record CreateBankAccount : OperationType { }

    public sealed record Replenishment(decimal Amount) : OperationType, IOperationWithAmount { }

    public sealed record Withdraw(decimal Amount) : OperationType, IOperationWithAmount { }

    public sealed record ViewBalance(decimal Amount) : OperationType, IOperationWithAmount { }
}