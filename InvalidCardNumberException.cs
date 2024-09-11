namespace LuhnAlgorithm;

public class InvalidCardNumberException : CreditCardException
{
    public InvalidCardNumberException(char c) : base($"Invalid credit card number: '{c}' is not a digit")
    {
    }
}
