// See https://aka.ms/new-console-template for more information
SwitchCase("Monday");
ForLoop();
ConsolReadline();

void ConsolReadline()
{
    Console.Write("請輸入你的名稱: ");
    string ? inputName = Console.ReadLine();
    Console.WriteLine($"哈囉,{inputName}");
    
    Console.Write("請輸入你的年齡: ");
    string ? inputAge = Console.ReadLine();
    if (int.TryParse(inputAge, out int age))
    {
        Console.WriteLine($"你的年齡是,{age}");
    }
    else
    {
        Console.WriteLine("年齡輸入錯誤");
    }

}

void ForLoop()
{
    List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
    foreach (int number in numbers) //java for(number : numbers)
    {
        if (number == 4)
        {
            continue;
        }
        else
        {
            Console.WriteLine(number);
        }
    }
}

void SwitchCase(string dayOfWeek)
{
    string[] weekdays = { "Monday", "Tuesday","Wednesday","Thursday,","Friday" };
    string[] weekends = { "Saturday", "Sunday" };
    if (weekdays.Contains(dayOfWeek))
    {
        Console.WriteLine("工作日");
    }
    else if (weekends.Contains(dayOfWeek))
    {
        Console.WriteLine("週末");
    }
    else
    {
        Console.WriteLine("未知日期");
    }
}





