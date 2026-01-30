namespace Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService.AlertSystemServiceEnteties;

public class ConsoleAlertSystem : IAlertSystemService
{
    public void Notify()
    {
        Console.WriteLine("Attention! All personal");
    }
}