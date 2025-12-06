using Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface IShowModeBuilder<T> : ICommandBuilder where T : IShowModeBuilder<T>
{
    T AddShowMode(IFileContentOutput fileContentOutput);
}