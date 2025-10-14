using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties;

public class AdresseUser : IAdresse
{
    private readonly User _user;

    public AdresseUser(User user)
    {
        _user = user;
    }

    public void GetMessage(Message message)
    {
        _user.GetMessage(message);
    }
}