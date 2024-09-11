namespace LuhnAlgorithm.CreditCardIssuers;

public class MasterCardCreditCard : CreditCard
{
    public MasterCardCreditCard(string creditCardNumber) : base(creditCardNumber)
    {
        CardNumberLength = 16;
        Issuer = "MasterCard";
    }

    protected override int CardNumberLength { get; }
    public override string Issuer { get; }
}
