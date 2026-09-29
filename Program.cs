using System.Security.Cryptography.X509Certificates;
using TCSA.OOP.LibraryManagementSystem;


/*Animal myDog = new Dog("vini", 3);
Animal myCat = new Cat("Nilo", 5);

myDog.MakeSound();
myCat.MakeSound();

internal abstract class Animal
{
    public string Name {get; set;}
    public int Age {get; set;}

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public abstract void MakeSound();
}

internal class Dog: Animal
{
    public Dog(string name, int age) 
        : base(name, age)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

internal class Cat: Animal
{
    public Cat(string name, int age)
        : base(name, age)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }
}*/

Userinterface userInterface = new();
userInterface.MainMenu();