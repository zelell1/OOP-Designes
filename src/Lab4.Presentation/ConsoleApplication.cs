using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class ConsoleApplication
{
    public static void Main()
    {
        var parser = new RootNode(new RootParserCommandFactory().Create());

        var session = new FileSystemSession(new FileSystemCore());

        while (true)
        {
            string? consoleCommand = Console.ReadLine();

            if (consoleCommand is null)
            {
                continue;
            }

            IEnumerator<string> iterator = consoleCommand
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .GetEnumerator();

            ParseBuildCommandResult parseResult = parser.Parse(iterator);

            if (parseResult is ParseBuildCommandResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
                continue;
            }

            if (parseResult is ParseBuildCommandResult.Success success)
            {
                IFileSystemCommand command = success.Command;

                FileSystemCommandResult commandResult = command.Run(session);

                if (commandResult is FileSystemCommandResult.Failure commandFailure)
                {
                    Console.WriteLine(commandFailure.Error);
                }

                if (commandResult is FileSystemCommandResult.Success commandSuccess)
                {
                    Console.WriteLine(commandSuccess.Text);
                }
            }
        }
    }
}