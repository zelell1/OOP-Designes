using Itmo.ObjectOrientedProgramming.Lab2.Logger;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Adresse.AdresseEnteties.Logger;

public class AdresseLogger : IAdresse
{
    private readonly ILogger _logger;

    private readonly IAdresse _adresse;

    public AdresseLogger(ILogger logger, IAdresse adresse)
    {
        _logger = logger;
        _adresse = adresse;
    }

    public AdresseLogger(IAdresse adresse) : this(new TimeAndMessageLogger(), adresse) { }

    public void GetMessage(Message message)
    {
        _logger.Log($"({DateTime.Now})[{message.Importance}] {message.Header}: {message.Body}");
        _adresse.GetMessage(message);
    }
}