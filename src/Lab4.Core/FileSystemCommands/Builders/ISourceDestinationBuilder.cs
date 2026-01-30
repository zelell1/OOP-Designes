namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface ISourceDestinationBuilder<T> : ICommandBuilder where T : ISourceDestinationBuilder<T>
{
    T AddSrc(string src);

    T AddDst(string dst);
}