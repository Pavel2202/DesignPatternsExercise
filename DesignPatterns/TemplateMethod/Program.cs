public class Creature
{
    public int Attack, Health;

    public Creature(int attack, int health)
    {
        this.Attack = attack;
        this.Health = health;
    }
}

public abstract class CardGame
{
    public Creature[] Creatures;

    public CardGame(Creature[] creatures)
    {
        Creatures = creatures;
    }

    public int Combat(int creature1, int creature2)
    {
        Creature first = Creatures[creature1];
        Creature second = Creatures[creature2];
        Hit(first, second);
        Hit(second, first);
        bool firstAlive = first.Health > 0;
        bool secondAlive = second.Health > 0;
        if (firstAlive == secondAlive)
        {
            return -1;
        }

        return firstAlive ? creature1 : creature2;
    }

    protected abstract void Hit(Creature attacker, Creature other);
}

public class TemporaryCardDamageGame : CardGame
{
    public TemporaryCardDamageGame(Creature[] creatures)
        : base(creatures)
    {
    }

    protected override void Hit(Creature attacker, Creature other)
    {
        var oldHealth = other.Health;
        other.Health -= attacker.Attack;
        if (other.Health > 0)
        {
            other.Health = oldHealth;
        }
    }
}

public class PermanentCardDamage : CardGame
{
    public PermanentCardDamage(Creature[] creatures)
        : base(creatures)
    {
    }

    protected override void Hit(Creature attacker, Creature other)
    {
        other.Health -= attacker.Attack;
    }
}

public class Program
{
    static void Main()
    {
        var c1 = new Creature(1, 2);
        var c2 = new Creature(1, 2);
        var temporaryGame = new TemporaryCardDamageGame(new[] { c1, c2 });
        temporaryGame.Combat(0, 1);
        Console.WriteLine(c1.Health);
        Console.WriteLine(c2.Health);

        var permanentGame = new PermanentCardDamage(new[] { c1, c2 });
        permanentGame.Combat(0, 1);
        Console.WriteLine(c1.Health);
        Console.WriteLine(c2.Health);
    }
}