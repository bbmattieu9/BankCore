namespace BankCore;

public static class IdGenerator
{
    public static string GenerateAccountNumber()
    {
        // Generates a random 10 digit number between 1000000000 and 9999999999
        long min = 1000000000L;
        long max = 9999999999L;
        long accountNumber = (long)(Random.Shared.NextDouble() * (max - min) + min);
        return accountNumber.ToString();
    }

    public static string GenerateCustomerId()
    {
        int id = Random.Shared.Next(1000000, 9999999);
        return $"ZBN{id}";
    }

    public static string GenerateTransactionId()
    {
        int id = Random.Shared.Next(100000, 999999);
        return $"TXN{id}";
    }
}