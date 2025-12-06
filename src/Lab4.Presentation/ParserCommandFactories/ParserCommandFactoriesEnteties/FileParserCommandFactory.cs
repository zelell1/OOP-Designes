using Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput.IFileContentOutputEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.FileCommandNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class FileParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        var fileShowModeFlagArgumentChain =
            new ShowModeNode<FileShowCommand.IFileShowCommandBuilder>(
                new FileContentConsoleOutput(),
                "console");

        var fileShowModeFlagChain =
            new FileShowModeFlag<FileShowCommand.IFileShowCommandBuilder>(fileShowModeFlagArgumentChain);

        var parametrsFileShowChain =
            new PathParametrNode<FileShowCommand.IFileShowCommandBuilder>();

        IParametrsChainParser parametrsFileCopyChain =
            new SourceParametrNode<FileCopyCommand.IFileCopyCommandBuilder>()
                .AddNext(new DestParametrNode<FileCopyCommand.IFileCopyCommandBuilder>());

        IParametrsChainParser parametrsFileMoveChain =
            new SourceParametrNode<FileMoveCommand.IFileMoveCommandBuilder>()
                .AddNext(new DestParametrNode<FileMoveCommand.IFileMoveCommandBuilder>());

        IParametrsChainParser parametrsFileDeleteChain =
            new PathParametrNode<FileDeleteCommand.IFileDeleteCommandBuilder>();

        IParametrsChainParser parametrsFileRenameChain =
            new PathParametrNode<FileRenameCommand.IFileRenameCommandBuilder>()
            .AddNext(new NameParametrNode<FileRenameCommand.IFileRenameCommandBuilder>());

        var fileShowChain = new FileShowNode(
            new EmptyNode(),
            parametrsFileShowChain,
            fileShowModeFlagChain);

        var fileCopyChain = new FileShowNode(
            new EmptyNode(),
            parametrsFileCopyChain,
            new EmptyFlagNode());

        var fileMoveChain = new FileShowNode(
            new EmptyNode(),
            parametrsFileMoveChain,
            new EmptyFlagNode());

        var fileDeleteChain = new FileShowNode(
            new EmptyNode(),
            parametrsFileDeleteChain,
            new EmptyFlagNode());

        var fileRenameChain = new FileShowNode(
            new EmptyNode(),
            parametrsFileRenameChain,
            new EmptyFlagNode());

        ICommandChainParser fileChain = fileShowChain
            .AddNext(fileCopyChain)
            .AddNext(fileMoveChain)
            .AddNext(fileDeleteChain)
            .AddNext(fileRenameChain);

        return new FileNode(fileChain, new EmptyParametrNode(), new EmptyFlagNode());
    }
}