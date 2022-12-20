public interface ILog
{
    int RecordLimit { get; }

    int RecordCount { get; set; }

    void LogInfo(string message);
}

public class Account
{
    private ILog log;

    public Account(ILog log)
    {
        this.log = log;
    }

    public void SomeOperation()
    {
        int c = log.RecordCount;
        log.LogInfo("Performing an operation.");
        if (c + 1 != log.RecordCount)
        {
            throw new Exception();
        }
        if (log.RecordCount >= log.RecordLimit)
        {
            throw new Exception();
        }
    }
}

public class NullLog : ILog
{
    public int RecordLimit { get; } = int.MaxValue;

    public int RecordCount { get; set; } = int.MinValue;

    public void LogInfo(string message)
    {
        ++RecordCount;
    }
}

public class Program
{
    static void Main()
    {
        var a = new Account(new NullLog());
        a.SomeOperation();
    }
}