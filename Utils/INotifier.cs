namespace inventorySystem.Utils;

public interface INotifier
{
    void SendNotifier( String recipient,string message );
    //void SendAlarm(string recipient);//庫存不足通知
}