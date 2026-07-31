namespace BankCore;

public class Customer
{
    public string CustomerId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime DateCreated { get; private set; }

    private readonly Logger _logger;

    public Customer(string customerId, string firstName, string lastName, string email, string phoneNumber)
    {
        this.CustomerId = customerId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.DateCreated = DateTime.Now;

        _logger = new Logger();
        _logger.Log($"Customer {FirstName} {LastName} created successfully.");
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public void UpdateEmail(string newEmail)
    {
        this.Email = newEmail;
        _logger.Log($"Email updated for {GetFullName()}");
    }

    public void GetDetails()
    {
        Console.WriteLine($"Customer ID  : {CustomerId}");
        Console.WriteLine($"Name         : {GetFullName()}");
        Console.WriteLine($"Email        : {Email}");
        Console.WriteLine($"Phone        : {PhoneNumber}");
        Console.WriteLine($"Member Since : {DateCreated.ToShortDateString()}");
    }
}