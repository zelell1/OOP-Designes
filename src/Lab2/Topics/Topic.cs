using Itmo.ObjectOrientedProgramming.Lab2.Adresse;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public TopicTitle Title { get; }

    private readonly Message _message;

    private readonly IReadOnlyCollection<IAdresse> _adresses;

    public Topic(TopicTitle title, Message message, IReadOnlyCollection<IAdresse> adresses)
    {
        Title = title;
        _message = message;
        _adresses = adresses;
    }

    public void GetMessage()
    {
        foreach (IAdresse adresse in _adresses)
        {
            adresse.GetMessage(_message);
        }
    }
}