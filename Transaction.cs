namespace BankCore;

public class Transaction
{
    public string TransactionId  { get; private set; }
    public string Type { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public string  AccountNumber { get; private set; }


    public Transaction(string transactionId, string type, decimal amount, string description, string accountNumber)
    {
        this.TransactionId = transactionId;
        this.Type = type;
        this.Amount = amount;   
        this.Description = description;
        this.AccountNumber = accountNumber;
        this.Date = DateTime.Now;
    }

    public void GetTransactionDetails()
    {
        Console.WriteLine($"Transaction ID : {TransactionId}");
        Console.WriteLine($"Type : {Type}");
        Console.WriteLine($"Amount : {Amount:C}");
        Console.WriteLine($"Date : {Date:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Description : {Description}");
        Console.WriteLine($"Account : {AccountNumber}");
    }
}