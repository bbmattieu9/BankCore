using BankCore;
using System.Globalization;

class Program
{
    private static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("ig-NG");
        
        
        var zenithBankAccountOpening = new Bank("Zenith Bank PLC");

        var customerAda = new Customer(
            IdGenerator.GenerateCustomerId(),
            "Ada", "Azama",
            "ada@gmail.com", "07020398766");

        var customerSophia = new Customer(
            IdGenerator.GenerateCustomerId(),
            "Sophia", "Collins", "sophia@mail.com", "07020398766");

        var adazAccount = new SavingsAccount(
            IdGenerator.GenerateAccountNumber(), customerAda);

        var sophiasAccount = new CurrentAccount(
            IdGenerator.GenerateAccountNumber(), customerSophia);

        var adaCreditTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Credit, 3000m,
            "Food Allowance", adazAccount.AccountNumber);
        
        var sophiaDebitTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Debit, 1000m,
            "School Fees", sophiasAccount.AccountNumber);

        zenithBankAccountOpening.AddAccount(adazAccount);
        zenithBankAccountOpening.AddAccount(sophiasAccount);
        adazAccount.ProcessTransaction(adaCreditTnx);
        sophiasAccount.ProcessTransaction(sophiaDebitTnx);

       

        
        Console.WriteLine("\n");
        adazAccount.GetTransactionHistory();
        Console.WriteLine("\n");
        sophiasAccount.GetTransactionHistory();
        
        
        Console.WriteLine("\n");
        adazAccount.GetAccountDetails();
        Console.WriteLine("\n");
        sophiasAccount.GetAccountDetails();
    }
}