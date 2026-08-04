namespace BankCore;

public class BankAccount
{
    public decimal Balance { get; protected set; }
    public string AccountNumber { get; private set; }
    public AccountType AccountType { get; private set; }
    public DateTime DateOpened { get; private set; }
    public bool IsActive { get; private set; }
    public Customer Owner { get; private set; }

    protected readonly Logger _logger;
    private readonly List<Transaction> _transactions;

    public BankAccount(string accountNumber, AccountType accountType, Customer owner)
    {
        this.Balance = 0;
        this.AccountNumber = accountNumber;
        this.AccountType = accountType;
        this.DateOpened = DateTime.Now;
        this.IsActive = true;
        this.Owner = owner;

        _transactions = new List<Transaction>();
        _logger = new Logger();
        _logger.Log($"Account {AccountNumber} opened for {Owner.GetFullName()}");
    }


    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError("Deposit amount must be greater than zero.");
            return false;
        }

        Balance += amount;
        _logger.LogSuccess($"Deposit of {amount:C} successful. New balance: {Balance:C}");
        return true;
    }


    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError("Withdrawal amount must be greater than zero.");
            return false;
        }

        if (amount > Balance)
        {
            _logger.LogError("Insufficient funds.");
            return false;
        }

        Balance -= amount;
        _logger.LogSuccess($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
        return true;
    }

    public void GetAccountDetails()
    {
        Console.WriteLine($"Account No   : {AccountNumber}");
        Console.WriteLine($"Account Type : {AccountType}");
        Console.WriteLine($"Owner        : {Owner.GetFullName()}");
        Console.WriteLine($"Balance      : {Balance:C}");
        Console.WriteLine($"Date Opened  : {DateOpened.ToShortDateString()}");
        Console.WriteLine($"Status       : {(IsActive ? "Active" : "Inactive")}");
    }

    public void ProcessTransaction(Transaction transaction)
    {
        bool success;

        if (transaction.Type == TransactionType.Credit)
            success = Deposit(transaction.Amount);
        else if (transaction.Type == TransactionType.Debit)
            success = Withdraw(transaction.Amount);
        else
        {
            _logger.LogError($"Unknown transaction type: {transaction.Type}");
            return;
        }

        if (success)
        {
            _transactions.Add(transaction);
            _logger.Log($"Transaction {transaction.TransactionId} recorded on account {AccountNumber}");
        }
    }

    public void GetTransactionHistory()
    {
        Console.WriteLine($"===== TRANSACTION HISTORY: {AccountNumber} =====");
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
        }
        else
        {
            foreach (var transaction in _transactions)
            {
                transaction.GetTransactionDetails();
            }
        }

        Console.WriteLine("==============================================");
    }
}