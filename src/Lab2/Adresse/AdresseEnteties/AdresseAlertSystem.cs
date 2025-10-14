using Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseAlertSystem : IAdresse
{
    private readonly IAlertSystemService _alertSystemService;

    private readonly AlertMessage _alertMessage;

    public AdresseAlertSystem(IAlertSystemService alertSystemService,  AlertMessage alertMessage)
    {
        _alertSystemService = alertSystemService;
        _alertMessage = alertMessage;
    }

    // TODO: нарушен srp надо исправить
    public void GetMessage(Message message)
    {
        foreach (string word in _alertMessage.Values)
        {
            if (message.Header.Value.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                message.Body.Value.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                _alertSystemService.Notify();
            }
        }
    }
}