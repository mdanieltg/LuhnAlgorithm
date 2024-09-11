namespace LuhnAlgorithm;

public class InvalidCardLengthException : CreditCardException
{
    public InvalidCardLengthException() : base("Invalid card length")
    {
    }
}
