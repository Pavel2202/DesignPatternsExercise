public class Game
{
    public event EventHandler RatEnters, RatDies;
    public event EventHandler<Rat> NotifyRat;

    public void FireRatEnters(object sender)
    {
        RatEnters?.Invoke(sender, EventArgs.Empty);
    }

    public void FireRatDies(object sender)
    {
        RatDies?.Invoke(sender, EventArgs.Empty);
    }

    public void FireNotifyRat(object sender, Rat whichRat)
    {
        NotifyRat?.Invoke(sender, whichRat);
    }
}

public class Rat : IDisposable
{
    private readonly Game game;
    public int Attack = 1;

    public Rat(Game game)
    {
        this.game = game;
        game.RatEnters += (sender, e) => 
        {
            if (sender != this)
            {
                ++Attack;
                game.FireNotifyRat(this, (Rat)sender);
            }
        };

        game.NotifyRat += (sender, rat) =>
        {
            if (rat == this)
            {
                Attack++;
            }
        };

        game.RatDies += (sender, args) => --Attack;
        game.FireRatEnters(this);
    }

    public void Dispose()
    {
        game.FireRatDies(this);
    }
}

public class Program
{
    static void Main()
    {
        var game = new Game();
        var rat = new Rat(game);
        Console.WriteLine(rat.Attack);

        var rat2 = new Rat(game);
        Console.WriteLine(rat.Attack);
        Console.WriteLine(rat2.Attack);

        using (var rat3 = new Rat(game))
        {
            Console.WriteLine(rat.Attack);
            Console.WriteLine(rat2.Attack);
            Console.WriteLine(rat3.Attack);
        }

        Console.WriteLine(rat.Attack);
        Console.WriteLine(rat2.Attack);
    }
}