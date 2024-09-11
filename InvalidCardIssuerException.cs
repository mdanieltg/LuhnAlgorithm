namespace LuhnAlgorithm;

public class InvalidCardIssuerException : CreditCardException
{
    public InvalidCardIssuerException() : base("Invalid credit card issuer")
    {
    }
}
