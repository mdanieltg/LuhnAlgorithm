using LuhnAlgorithm;

if (args.Length == 0)
{
    Console.WriteLine("No cards provided.");
    return;
}

foreach (string rawCard in args)
    try
    {
        var creditCard = CreditCard.Create(rawCard);
        Console.WriteLine("The credit card {0} ({1}) is valid.", creditCard, creditCard.Issuer);
    }
    catch (CreditCardException)
    {
        Console.WriteLine("The credit card {0} is invalid", rawCard);
    }
