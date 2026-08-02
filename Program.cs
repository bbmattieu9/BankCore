using BankCore;
using System.Globalization;

class Program
{
    private static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("ig-NG");
        var bank = new Bank("Zenith Bank");

        var customerMatt = new Customer(
            IdGenerator.GenerateCustomerId(),
            "Babatunde",
            "Ogunmola",
            "bbmattieu9@gmail.com",
            "07042020381");

        var mattAccount = new BankAccount(
            IdGenerator.GenerateAccountNumber(),
            "Current",
            customerMatt);

        var mattCreditTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            "Credit",
            2000,
            "Birthday Gift",
            mattAccount.AccountNumber);
        bank.RecordTransaction(mattCreditTnx);

        var customerDami = new Customer(
            IdGenerator.GenerateCustomerId(),
            "Damilola",
            "Osiname",
            "damag89@gmail.com",
            "07042020381");

        bank.AddCustomer(customerMatt);
        bank.AddCustomer(customerDami);

        var damiAccount = new BankAccount(IdGenerator.GenerateAccountNumber(), "Savings", customerDami);

        bank.AddAccount(mattAccount);
        bank.AddAccount(damiAccount);

        var damiCreditTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            "Credit",
            9000,
            "Allowance",
            damiAccount.AccountNumber);
        bank.RecordTransaction(damiCreditTnx);

        mattAccount.Deposit(mattCreditTnx.Amount);
        damiAccount.Deposit(damiCreditTnx.Amount);

        var mattDebitTnxAction = new Transaction(
            IdGenerator.GenerateTransactionId(),
            "Debit",
            500,
            "Internet bill",
            mattAccount.AccountNumber);
        bank.RecordTransaction(mattDebitTnxAction);

        Console.WriteLine("\n");
        bank.GetAllCustomers();
        Console.WriteLine("\n");
        bank.GetAllAccounts();
        Console.WriteLine("\n");
        bank.GetAllTransactions();
    }
}