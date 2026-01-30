namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;

public abstract class AttackResult
{
    private AttackResult() { }

    public sealed class Dead : AttackResult { }

    public sealed class NotDead : AttackResult { }
}