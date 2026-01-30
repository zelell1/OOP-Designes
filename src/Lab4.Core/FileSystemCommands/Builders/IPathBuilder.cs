namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface IPathBuilder<T> : ICommandBuilder where T : IPathBuilder<T>
{
    T AddPath(string path);
}