using System.Text;

namespace LuhnAlgorithm.CreditCardIssuers;

public class AmericanExpressCreditCard : CreditCard
{
    public AmericanExpressCreditCard(string creditCardNumber) : base(creditCardNumber)
    {
        CardNumberLength = 15;
        Issuer = "American Express";
        LastDigits = creditCardNumber.Substring(creditCardNumber.Length - 5);
    }

    protected override int CardNumberLength { get; }
    public override string Issuer { get; }
    public override string LastDigits { get; }

    public override string PrintUnprotected()
    {
        StringBuilder sb = new();
        ReadOnlySpan<char> creditCardNumber = CreditCardNumber.AsSpan();

        for (var i = 0; i < CreditCardNumber.Length; ++i)
        {
            if (i == 4 || i == 10) sb.Append(' ');
            sb.Append(creditCardNumber[i]);
        }

        return sb.ToString();
    }
}
