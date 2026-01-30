using Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseAlertSystem : IAdresse
{
    private readonly IAlertSystemService _alertSystemService;

    private readonly IReadOnlyCollection<string> _bannedWords;

    public AdresseAlertSystem(IAlertSystemService alertSystemService, IReadOnlyCollection<string> bannedWords)
    {
        _alertSystemService = alertSystemService;
        _bannedWords = bannedWords;
    }

    public void GetMessage(Message message)
    {
        foreach (string word in _bannedWords)
        {
            if (message.Header.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                message.Body.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                _alertSystemService.Notify();
                return;
            }
        }
    }
}