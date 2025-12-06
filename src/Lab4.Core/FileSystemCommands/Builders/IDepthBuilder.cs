namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface IDepthBuilder<T> : ICommandBuilder where T : IDepthBuilder<T>
{
    T AddDepth(int depth);
}