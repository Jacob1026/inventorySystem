namespace inventorySystem.Models;

public class Cat :Animal
{
    public Cat()
    {
    }

    public Cat(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} 喵喵" );
    }
}