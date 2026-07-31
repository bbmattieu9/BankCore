namespace BankCore;

public class Bank
{
    public string Name { get; private set; }

    private readonly Logger _logger;
    private readonly List<Customer> _customers;
    private readonly List<BankAccount> _accounts;
    private readonly List<Transaction> _transactions;

    public Bank(string name)
    {
        this.Name = name;
        _logger = new Logger();
        _customers = new List<Customer>();
        _accounts = new List<BankAccount>();
        _transactions = new List<Transaction>();
        _logger.Log($"{Name} banking system initialised.");
    }

    public void AddCustomer(Customer customer)
    {
        this._customers.Add(customer);
        _logger.Log($"Customer {customer.GetFullName()} added to {Name}.");
    }

    public void AddAccount(BankAccount account)
    {
        this._accounts.Add(account);
        _logger.Log($"Account {account.AccountNumber} added to {Name}.");
    }

    public void RecordTransaction(Transaction transaction)
    {
        this._transactions.Add(transaction);
        _logger.Log($"Transaction {transaction.TransactionId} recorded.");
    }

    public void GetAllCustomers()
    {
        Console.WriteLine("===== ALL CUSTOMERS =====");
        foreach (var customer in this._customers)
        {
            customer.GetDetails();
        }

        Console.WriteLine("=========================");
    }

    public void GetAllAccounts()
    {
        Console.WriteLine("===== ALL ACCOUNTS =====");
        foreach (var account in this._accounts)
        {
            account.GetAccountDetails();
        }

        Console.WriteLine("=========================");
    }

    public void GetAllTransactions()
    {
        Console.WriteLine("===== ALL TRANSACTIONS =====");
        foreach (var transaction in this._transactions)
        {
            transaction.GetTransactionDetails();
        }

        Console.WriteLine("=========================");
    }
}