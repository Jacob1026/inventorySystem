namespace inventorySystem.Utils;

public class SmsNotifier:INotifier
{
    public void SendNotifier(string recipient, string message)
    {
        Console.WriteLine($"發送簡訊至{recipient}:{message}");
        //發送簡訊邏輯實作
        
    }
}