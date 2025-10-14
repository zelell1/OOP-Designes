namespace Itmo.ObjectOrientedProgramming.Lab2.Moderator.ModeratorEnteties;

public class WordsModerator : IModerator
{
    public bool ContainsBannedWords(string text, IReadOnlyCollection<string> bannedWords)
    {
        foreach (string word in bannedWords)
        {
            if (text.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                text.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}