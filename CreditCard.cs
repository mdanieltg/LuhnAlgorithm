using System.Text;
using LuhnAlgorithm.CreditCardIssuers;

namespace LuhnAlgorithm;

public abstract class CreditCard
{
    protected CreditCard(string creditCardNumber)
    {
        CreditCardNumber = creditCardNumber;
        LastDigits = creditCardNumber.Substring(creditCardNumber.Length - 4);
    }

    protected abstract int CardNumberLength { get; }
    public abstract string Issuer { get; }
    public string CreditCardNumber { get; }
    public virtual string LastDigits { get; }

    public virtual string PrintProtected() => $"*******{LastDigits}";

    public virtual string PrintUnprotected()
    {
        StringBuilder sb = new();
        ReadOnlySpan<char> creditCardNumber = CreditCardNumber.AsSpan();

        for (var i = 0; i < CreditCardNumber.Length; ++i)
        {
            if (i != 0 && i % 4 == 0) sb.Append(' ');
            sb.Append(creditCardNumber[i]);
        }

        return sb.ToString();
    }

    public override string ToString()
    {
        return PrintProtected();
    }

    private static CreditCardIssuer GetIssuer(string creditCardNumber)
    {
        ReadOnlySpan<char> creditCardNumbers = creditCardNumber.AsSpan();
        return creditCardNumbers[0] switch
        {
            '3' when creditCardNumbers[1] == '5' || creditCardNumbers[1] == '7' => CreditCardIssuer.AmericanExpress,
            '4' => CreditCardIssuer.Visa,
            '5' => CreditCardIssuer.MasterCard,
            '6' => CreditCardIssuer.Discover,
            _ => throw new InvalidCardIssuerException()
        };
    }

    public static bool IsValid(string creditCardNumber) => IsValid(creditCardNumber.AsSpan());

    public static bool IsValid(ReadOnlySpan<char> creditCardNumber)
    {
        if (creditCardNumber.Length != 15 && creditCardNumber.Length != 16) throw new InvalidCardLengthException();

        var sum = 0;
        for (var i = 1; i <= creditCardNumber.Length; i++)
        {
            int index = creditCardNumber.Length - i;
            if (!char.IsDigit(creditCardNumber[index])) throw new InvalidCardNumberException(creditCardNumber[index]);

            var digit = (int) char.GetNumericValue(creditCardNumber[index]);
            if (i % 2 == 0)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
        }

        return sum % 10 == 0;
    }

    public static CreditCard Create(string creditCardNumber)
    {
        if (!IsValid(creditCardNumber)) throw new InvalidCreditCardException();

        CreditCardIssuer cardIssuer = GetIssuer(creditCardNumber);
        return cardIssuer switch
        {
            CreditCardIssuer.AmericanExpress => new AmericanExpressCreditCard(creditCardNumber),
            CreditCardIssuer.Visa => new VisaCreditCard(creditCardNumber),
            CreditCardIssuer.MasterCard => new MasterCardCreditCard(creditCardNumber),
            _ => throw new NotImplementedException($"Card issuer not implemented: {cardIssuer}.")
        };
    }
}
