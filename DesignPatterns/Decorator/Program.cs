using System;

public class Bird
{
    public int Age { get; set; }

    public string Fly()
    {
        return (Age < 10) ? "flying" : "too old";
    }
}

public class Lizard
{
    public int Age { get; set; }

    public string Crawl()
    {
        return (Age > 1) ? "crawling" : "too young";
    }
}

public class Dragon
{
    private int age;
    private Bird bird = new Bird();
    private Lizard lizard = new Lizard();

    public int Age
    {
        get { return Age; }
        set { age = bird.Age = lizard.Age = value;  }
    }

    public string Fly()
    {
        return bird.Fly();
    }

    public string Crawl()
    {
        return lizard.Crawl();
    }
}

public class Program
{
    static void Main()
    {
        var dragon1 = new Dragon { Age = 8 };
        var dragon2 = new Dragon { Age = 11 };
        var dragon3 = new Dragon { Age = 1 };

        Console.WriteLine(dragon1.Fly());
        Console.WriteLine(dragon1.Crawl());
        Console.WriteLine(dragon2.Fly());
        Console.WriteLine(dragon2.Crawl());
        Console.WriteLine(dragon3.Fly());
        Console.WriteLine(dragon3.Crawl());
    }
}