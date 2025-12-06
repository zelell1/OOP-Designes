using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTests
{
    [Fact]
    public void Parser_CorrectConnectWithoutFlags_Success()
    {
        // Arrange
        const string command = "connect /home";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList()
                                        .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<ConnectCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_CorrectConnectWithFlags_Success()
    {
        // Arrange
        const string command = "connect /home -m local";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<ConnectCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_DisconnectCommand_Success()
    {
        // Arrange
        const string command = "disconnect";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<DisconnectCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_DisconnectCommandWithMoreArgumentsThanNecessary_FailureUnknownFlag()
    {
        // Arrange
        const string command = "disconnect -m 5";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Unknown flag", failure.Error);
        }
    }

    [Fact]
    public void Parse_EmptyCommand_FailureUnkownCommand()
    {
        // Arrange
        const string command = "";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Unknown command", failure.Error);
        }
    }

    [Fact]
    public void Parse_TreeGoto_Success()
    {
        // Arrange
        const string command = "tree goto /home";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<TreeGotoCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_TreeListWithNecessaryFlag_Success()
    {
        // Arrange
        const string command = "tree list -d 3";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<TreeListCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_TreeListWithoutFlagArgumentFlag_Success()
    {
        // Arrange
        const string command = "tree list -d";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Depth must have a value", failure.Error);
        }
    }

    [Fact]
    public void Parse_TreeListWithoutFlag_Success()
    {
        // Arrange
        const string command = "tree list";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success success)
        {
            Assert.IsType<TreeListCommand>(success.Command);
        }
    }

    [Fact]
    public void Parse_FileShowCommand_Failure()
    {
        // Arrange
        const string command = "file show";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Neccesary flag missed", failure.Error);
        }
    }

    [Fact]
    public void Parse_FileShowCommandWithParametr_Failure()
    {
        // Arrange
        const string command = "file show /home";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Neccesary flag missed", failure.Error);
        }
    }

    [Fact]
    public void Parse_FileShowCommand_Success()
    {
        // Arrange
        const string command = "file show /home -m console";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success failure)
        {
            Assert.IsType<FileShowCommand>(failure.Command);
        }
    }

    [Fact]
    public void Parse_FileCopyCommand_Success()
    {
        // Arrange
        const string command = "file copy /home /home1";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success failure)
        {
            Assert.IsType<FileCopyCommand>(failure.Command);
        }
    }

    [Fact]
    public void Parse_FileMoveCommand_Success()
    {
        // Arrange
        const string command = "file move /home /home1";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success failure)
        {
            Assert.IsType<FileMoveCommand>(failure.Command);
        }
    }

    [Fact]
    public void Parse_FileDeleteCommand_Success()
    {
        // Arrange
        const string command = "file delete /home";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success failure)
        {
            Assert.IsType<FileDeleteCommand>(failure.Command);
        }
    }

    [Fact]
    public void Parse_FileRenameCommand_Success()
    {
        // Arrange
        const string command = "file rename /home castle";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Success>(result);

        if (result is ParseBuildCommandResult.Success failure)
        {
            Assert.IsType<FileRenameCommand>(failure.Command);
        }
    }

    [Fact]
    public void Parse_RandomeCommands_Fail()
    {
        // Arrange
        const string command = "file list rename copy /home castle";
        var parser = new RootNode(new RootParserCommandFactory().Create());

        IEnumerator<string> iterator = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .GetEnumerator();

        // Act
        ParseBuildCommandResult result = parser.Parse(iterator);

        // Assert
        Assert.IsType<ParseBuildCommandResult.Failure>(result);

        if (result is ParseBuildCommandResult.Failure failure)
        {
            Assert.Equal("Too many arguments", failure.Error);
        }
    }
}