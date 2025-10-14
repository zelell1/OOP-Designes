namespace Itmo.ObjectOrientedProgramming.Lab2.Moderator;

public interface IModerator
{
    bool ContainsBannedWords(string text, IReadOnlyCollection<string> bannedWords);
}