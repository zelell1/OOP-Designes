using Itmo.ObjectOrientedProgramming.Lab2.Archiver;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseArciver : IAdresse
{
    private readonly IArchiver _archiver;

    public AdresseArciver(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void GetMessage(Message message)
    {
        _archiver.Archive(message);
    }
}