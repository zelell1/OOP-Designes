using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService.AlertSystemServiceEnteties;

public class ConsoleAlertSystem : IAlertSystemService
{
    private readonly AlertMessage _alertMessage;

    public ConsoleAlertSystem(AlertMessage alertMessage)
    {
        _alertMessage = alertMessage;
    }

    public void Notify()
    {
        Console.WriteLine(_alertMessage);
    }
}