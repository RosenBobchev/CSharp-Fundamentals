using System;

public class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.Eating();
        dog.Bark();

        Cat cat = new Cat();
        cat.Eating();
        cat.Meow();
    }
}

