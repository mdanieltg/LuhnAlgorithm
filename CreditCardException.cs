namespace LuhnAlgorithm;

public class CreditCardException : Exception
{
    public CreditCardException()
    {
    }

    public CreditCardException(string message) : base(message)
    {
    }
}
