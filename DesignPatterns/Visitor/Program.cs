using System.Text;

public abstract class ExpressionVisitor
{
    public abstract void Visit(Value value);
    public abstract void Visit(AdditionExpression value);
    public abstract void Visit(MultiplicationExpression value);
}

public abstract class Expression
{
    public abstract void Accept(ExpressionVisitor visitor);
}

public class Value : Expression
{
    public readonly int TheValue;

    public Value(int value)
    {
        TheValue = value;
    }

    public override void Accept(ExpressionVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class AdditionExpression : Expression
{
    public readonly Expression LHS, RHS;

    public AdditionExpression(Expression lhs, Expression rhs)
    {
        LHS = lhs;
        RHS = rhs;
    }

    public override void Accept(ExpressionVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class MultiplicationExpression : Expression
{
    public readonly Expression LHS, RHS;

    public MultiplicationExpression(Expression lhs, Expression rhs)
    {
        LHS = lhs;
        RHS = rhs;
    }

    public override void Accept(ExpressionVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ExpressionPrinter : ExpressionVisitor
{
    private StringBuilder sb = new StringBuilder();

    public override void Visit(Value value)
    {
        sb.AppendLine(value.TheValue.ToString());
    }

    public override void Visit(AdditionExpression value)
    {
        sb.Append("(");
        value.LHS.Accept(this);
        sb.Append("+");
        value.RHS.Accept(this);
        sb.Append(")");
    }

    public override void Visit(MultiplicationExpression value)
    {
        value.LHS.Accept(this);
        sb.Append("*");
        value.RHS.Accept(this);
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}

public class Program
{
    static void Main()
    {
        var simple = new AdditionExpression(new Value(2), new Value(3));
        var ep = new ExpressionPrinter();
        ep.Visit(simple);
        Console.WriteLine(ep.ToString());
    }
}