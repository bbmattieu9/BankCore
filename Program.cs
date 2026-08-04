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

        var mattAccount = new CurrentAccount(
            IdGenerator.GenerateAccountNumber(),
            customerMatt,
            50000m
        );


        var mattCreditTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Credit,
            2000,
            "Birthday Gift",
            mattAccount.AccountNumber);


        var customerDami = new Customer(
            IdGenerator.GenerateCustomerId(),
            "Damilola",
            "Osiname",
            "damag89@gmail.com",
            "07042020381");

        bank.AddCustomer(customerMatt);
        bank.AddCustomer(customerDami);

        var damiAccount = new SavingsAccount(
            IdGenerator.GenerateAccountNumber(),
            customerDami);

        var damiOverdrawTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Debit,
            8500,
            "ATM Withdrawal",
            damiAccount.AccountNumber);
        damiAccount.ProcessTransaction(damiOverdrawTnx);

        bank.AddAccount(mattAccount);
        bank.AddAccount(damiAccount);

        var damiCreditTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Credit,
            9000,
            "Allowance",
            damiAccount.AccountNumber);


        mattAccount.ProcessTransaction(mattCreditTnx);
        damiAccount.ProcessTransaction(damiCreditTnx);

        // var mattDebitTnxAction = new Transaction(
        //     IdGenerator.GenerateTransactionId(),
        //     TransactionType.Debit,
        //     500,
        //     "Internet bill",
        //     mattAccount.AccountNumber);
        // mattAccount.ProcessTransaction(mattDebitTnxAction);
        
        var mattOverdraftTnx = new Transaction(
            IdGenerator.GenerateTransactionId(),
            TransactionType.Debit,
            2400,
            "Overdraft test",
            mattAccount.AccountNumber);
        mattAccount.ProcessTransaction(mattOverdraftTnx);

        Console.WriteLine("\n");
        mattAccount.GetTransactionHistory();
        Console.WriteLine("\n");
        damiAccount.GetTransactionHistory();
    }
}