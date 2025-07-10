using inventorySystem.Utils;

namespace inventorySystem.Services;

public class NotificationSeverice
{
    private readonly INotifier _notifier;

    public NotificationSeverice(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void NotifyUser(String recipient, string message)
    {
        Console.WriteLine($"準備通知用戶:{recipient}");
        _notifier.SendNotifier(recipient, message);
        Console.WriteLine("通知操作完成");
    }
}