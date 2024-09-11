namespace LuhnAlgorithm.CreditCardIssuers;

public class VisaCreditCard : CreditCard
{
    public VisaCreditCard(string creditCardNumber) : base(creditCardNumber)
    {
        CardNumberLength = 16;
        Issuer = "Visa";
    }

    protected override int CardNumberLength { get; }
    public override string Issuer { get; }
}
