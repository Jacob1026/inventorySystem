// See https://aka.ms/new-console-template for more information

using inventorySystem.Models;
using inventorySystem.Repositories;
using inventorySystem.Services;
using inventorySystem.Utils;


const string mysql_connetion_string = 
    "Server=localhost;Port=3306;Database=inventory_db;uid=root;pwd=Ji3g4284;";

//MySqlProductRepository ProductRepository = new MySqlProductRepository(mysql_connetion_string);
IProductRepository productRepository = new MySqlProductRepository(mysql_connetion_string);
InventoryService inventoryService = new InventoryService(productRepository);
//通知相關功能
//使用EmailNotifier
EmailNotifier emailNotifier = new EmailNotifier();
NotificationSeverice emailSeverice =new  NotificationSeverice(emailNotifier);

SmsNotifier smsNotifier = new SmsNotifier();
NotificationSeverice smsSeverice =new  NotificationSeverice(smsNotifier);
void RunMenu()
{
    while (true)
    {
        DisplayMenu();
        string input = Console.ReadLine();
        switch (input) 
        {
            case "1": GetAllProducts();
                break;
            case "2": SearchProduct();
                break;
            case "3": AddProduct();
                break;
            case "0": 
                Console.WriteLine("Goodbye !");
                return;
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("Welcome to the inventory system!");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. 查看所有產品");
    Console.WriteLine("2. 查詢產品");
    Console.WriteLine("3. 新增產品");
    Console.WriteLine("0. 離開");
}
void GetAllProducts()
{
    Console.WriteLine("\n--- 所有產品列表 ---");
    //var products = productRepository.GetAllProducts();
    var products = inventoryService.GetAllProducts();
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("ID | Name | Price | Quantity | Status");
    Console.WriteLine("-----------------------------------------------");
    foreach (var product in products)
    {
        Console.WriteLine(product);
    }
    Console.WriteLine("-----------------------------------------------");
    emailSeverice.NotifyUser(recipient:"Jacob","查詢完成");
    
}
void SearchProduct()
{
    Console.WriteLine("輸入欲查詢的產品編號");
    int input = ReadIntLine(1);
    var product = productRepository.GetProductById(input);
    // string input = Console.ReadLine();
    // var product = productRepository.GetProductById(ReadInt(input));
    if (product != null)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(product);
        Console.WriteLine("-----------------------------------------------");
    }
}
void AddProduct()
{
    Console.WriteLine("輸入產品名稱：");
    string name = Console.ReadLine();
    Console.WriteLine("輸入產品價格：");
    decimal price = ReadDecimalLine();
    Console.WriteLine("輸入產品數量：");
    int quantity = ReadIntLine();
    productRepository.AddProduct(name, price, quantity);
    smsSeverice.NotifyUser(recipient:"Jacob","新增產品成功");
}
int ReadInt(string input)
{
    try
    {
        return Convert.ToInt32(input);
    }
    catch (FormatException e)
    {
        Console.WriteLine("請輸入有效數字。");
        return 0;
    }
}
int ReadIntLine(int defaultValue = 0)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (int.TryParse(input,out int value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}
decimal ReadDecimalLine(decimal defaultValue = 0.0m)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0.0m)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (decimal.TryParse(input,out decimal value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}