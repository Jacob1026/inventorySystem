namespace inventorySystem.Models;

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public Dog()
    {
    }
    

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} bar bar" );
    }
}