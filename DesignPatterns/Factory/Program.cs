public class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
    }
}

public class PersonFactory
{
    private int id = 0;

    public Person CreatePerson(string name)
    {
        return new Person { Id = id++, Name = name };
    }
}

public class Program
{
    static void Main()
    {
        var pf = new PersonFactory();
        var john = pf.CreatePerson("John");
        var jane = pf.CreatePerson("Jane");

        Console.WriteLine(john);
        Console.WriteLine(jane);
    }
}