public class CombinationLock
{
    public string Status;
    private readonly int[] combination;
    private int digitsEntered = 0;
    private bool failed = false;

    public CombinationLock(int[] combination)
    {
        this.combination = combination;
        Reset();
    }

    private void Reset()
    {
        Status = "Locked";
        digitsEntered = 0;
        failed = false;
    }

    public void EnterDigit(int digit)
    {
        if (Status == "Locked")
        {
            Status = string.Empty;
        }

        Status += digit.ToString();
        if (combination[digitsEntered] != digit)
        {
            failed = true;
        }
        digitsEntered++;

        if (digitsEntered == combination.Length)
        {
            Status = failed ? "Error" : "Open";
        }
    }
}

public class Program
{
    static void Main()
    {
        var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine(cl.Status);
        cl.EnterDigit(1);
        Console.WriteLine(cl.Status);
        cl.EnterDigit(2);
        Console.WriteLine(cl.Status);
        cl.EnterDigit(3);
        Console.WriteLine(cl.Status);
        cl.EnterDigit(4);
        Console.WriteLine(cl.Status);
        cl.EnterDigit(5);
        Console.WriteLine(cl.Status);
    }
}