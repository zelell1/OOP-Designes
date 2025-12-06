namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface ISrcDstBuilder<T> : ICommandBuilder where T : ISrcDstBuilder<T>
{
    T AddSrc(string src);

    T AddDst(string dst);
}