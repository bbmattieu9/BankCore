
using BankCore;

using System.Globalization;

class Program
{
    private static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("ig-NG");
        var bank = new Bank("Zenith Bank");

        var customerMatt = new Customer(
            "CUST001",
            "Babatunde",
            "Ogunmola",
            "bbmattieu9@gmail.com",
            "07042020381");

        var customerDami = new Customer(
            "CUST002",
            "Damilola",
            "Osiname",
            "damag89@gmail.com",
            "07042020381");


        bank.AddCustomer(customerMatt);
        bank.AddCustomer(customerDami);

        var mattAccount = new BankAccount("0023291889", "Current", customerMatt);
        var damiAccount = new BankAccount("0022219018", "Savings", customerDami);

        bank.AddAccount(mattAccount);
        bank.AddAccount(damiAccount);

        var mattCreditTnx = new Transaction(
            "tnx010",
            "Credit",
            2000,
            "Birthday Gift",
            mattAccount.AccountNumber);
        bank.RecordTransaction(mattCreditTnx);

        var damiCreditTnx = new Transaction(
            "tnx0021",
            "Credit",
            9000,
            "Allowance",
            damiAccount.AccountNumber);
        bank.RecordTransaction(damiCreditTnx);

        mattAccount.Deposit(mattCreditTnx.Amount);
        damiAccount.Deposit(damiCreditTnx.Amount);

        var mattDebitTnxAction = new Transaction(
            "tnx0022",
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