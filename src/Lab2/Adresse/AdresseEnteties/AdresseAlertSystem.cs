using Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Moderator;
using Itmo.ObjectOrientedProgramming.Lab2.Moderator.ModeratorEnteties;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseAlertSystem : IAdresse
{
    private readonly IAlertSystemService _alertSystemService;

    private readonly AlertMessage _alertMessage;

    private readonly IModerator _moderator;

    public AdresseAlertSystem(IAlertSystemService alertSystemService, AlertMessage alertMessage, IModerator moderator)
    {
        _alertSystemService = alertSystemService;
        _alertMessage = alertMessage;
        _moderator = moderator;
    }

    public AdresseAlertSystem(IAlertSystemService alertSystemService, AlertMessage alertMessage)
        : this(alertSystemService, alertMessage, new WordsModerator()) { }

    public void GetMessage(Message message)
    {
        if (_moderator.ContainsBannedWords(message.Header.Value, _alertMessage.Values)
            || _moderator.ContainsBannedWords(message.Body.Value, _alertMessage.Values))
        {
            _alertSystemService.Notify();
        }
    }
}