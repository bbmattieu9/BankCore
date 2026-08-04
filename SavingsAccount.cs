namespace BankCore;

public class SavingsAccount: BankAccount
{
    private const decimal MINIMUM_BALANCE = 1000m;
    

    public SavingsAccount(string accountNumber, Customer owner)
        : base(accountNumber, AccountType.Savings, owner)
    { }


    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            _logger.LogError("Withdrawal amount must be greater than zero.");
            return false;
        }
        if ((Balance - amount) < MINIMUM_BALANCE)
        {
            _logger.LogError($"Insufficient funds. Savings account minimum balance is ₦{MINIMUM_BALANCE:N0}");
            return false;
        }
        Balance -= amount;
        _logger.LogSuccess($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
        return true;
    }
}