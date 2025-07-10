namespace inventorySystem.Utils;

public class EmailNotifier: INotifier
{
    public void SendNotifier(string recipient, string message)
    {
        Console.WriteLine($"發送Email至{recipient}:{message}");
        //發送簡訊邏輯實作
    }
}