namespace LuhnAlgorithm;

public class InvalidCreditCardException : CreditCardException
{
    public InvalidCreditCardException() : base("Invalid credit card")
    {
    }
}
