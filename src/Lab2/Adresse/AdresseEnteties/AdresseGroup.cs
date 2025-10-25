using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseGroup : IAdresse
{
    private readonly IReadOnlyCollection<IAdresse> _adresse;

    public AdresseGroup(IReadOnlyCollection<IAdresse> adresse)
    {
        _adresse = adresse;
    }

    public void GetMessage(Message message)
    {
        foreach (IAdresse adresse in _adresse)
        {
            adresse.GetMessage(message);
        }
    }
}