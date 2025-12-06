namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface INameBuilder<T> : ICommandBuilder where T : INameBuilder<T>
{
    T AddName(string name);
}