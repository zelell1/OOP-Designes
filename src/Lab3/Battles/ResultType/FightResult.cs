namespace Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;

public abstract class FightResult
{
    private FightResult() { }

    public sealed class FirstPlayerWin : FightResult { }

    public sealed class SecondPlayerWin : FightResult { }

    public sealed class Draw : FightResult { }
}