namespace Itmo.ObjectOrientedProgramming.Lab2.AlertSystemService.AlertSystemServiceEnteties;

public class SoundAlertSystem : IAlertSystemService
{
    public void Notify()
    {
        Console.Beep();
    }
}