namespace BankCore;

public class CurrentAccount : BankAccount
{
    private readonly decimal _overdraftLimit;

    public CurrentAccount(string accountNumber, Customer owner, decimal overdraftLimit = 5000m)
        : base(accountNumber, AccountType.Current, owner)
    {
        _overdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError("Withdrawal amount must be greater than zero.");
            return false;
        }

        if (amount > Balance + _overdraftLimit)
        {
            _logger.LogError($"Exceeds overdraft limit. Available balance: ₦{(Balance + _overdraftLimit):N0}");
            return false;
        }

        Balance -= amount;
        _logger.LogSuccess($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
        return true;
    }
}