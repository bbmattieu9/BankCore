namespace BankCore;

public class BankAccount
{
    public decimal Balance { get; private set; }
    public string AccountNumber { get; private set; }
    public string AccountType { get; private set; }
    public DateTime DateOpened { get; private set; }
    public bool IsActive { get; private set; }
    public Customer Owner { get; private set; }

    private readonly Logger _logger;

    public BankAccount(string accountNumber, string accountType, Customer owner)
    {
        this.Balance = 0;
        this.AccountNumber = accountNumber;
        this.AccountType = accountType;
        this.DateOpened = DateTime.Now;
        this.IsActive = true;
        this.Owner = owner;

        _logger = new Logger();
        _logger.Log($"Account {AccountNumber} opened for {Owner.GetFullName()}");
    }


    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError($"Deposit amount must be greater than zero");
            return;
        }
        else
        {
            this.Balance += amount;
            _logger.LogSuccess($"Deposit of {amount:C} successful. New balance: {Balance:C}");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError($"Withdrawal amount must be greater than zero");
            return;
        }

        if (amount > this.Balance)
        {
            _logger.LogError("Insufficient funds.");
        }
        else
        {
            this.Balance -= amount;
            _logger.LogSuccess($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
        }
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
}