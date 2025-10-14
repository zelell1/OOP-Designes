using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties.Filter;

public class AdresseImportanceFilter : IAdresse
{
    private readonly ImportanceLevel _importanceLevel;

    private readonly IAdresse _adresse;

    public AdresseImportanceFilter(ImportanceLevel importanceLevel, IAdresse adresse)
    {
        _importanceLevel = importanceLevel;
        _adresse = adresse;
    }

    public void GetMessage(Message message)
    {
        if (message.Importance.Value >= _importanceLevel.Value)
        {
            _adresse.GetMessage(message);
        }
    }
}