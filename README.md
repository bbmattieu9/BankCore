# BankCore 

A C# .NET console application demonstrating core Object-Oriented Programming (OOP) principles through a simulated banking system.

Built as part of a structured C# .NET learning journey targeting enterprise backend development.

---

## Concepts Demonstrated

| Concept | Where Applied |
|---|---|
| **Encapsulation** | `Balance` on `BankAccount` is read-only externally — only changes via `Deposit()` and `Withdraw()` |
| **Composition** | `BankAccount` and `Customer` each own a `Logger` instance |
| **Access Modifiers** | Public getters, private setters throughout all classes |
| **Readonly Fields** | `Logger` and `List<T>` fields marked `readonly` — assigned once in constructor |
| **Constructors** | Every class initialises and validates its own state on creation |
| **Instance Methods** | All behaviour encapsulated inside the class it belongs to |

---

## Project Structure

```
BankCore/
├── Logger.cs          # Logging utility — composition dependency
├── Customer.cs        # Customer entity with encapsulated properties
├── BankAccount.cs     # Account with deposit/withdraw logic and balance protection
├── Transaction.cs     # Immutable transaction record
├── Bank.cs            # Manages customers, accounts and transactions
└── Program.cs         # Entry point — wires everything together
```

---

## Classes

### `Logger`
Shared logging utility injected via composition into other classes.
```
[LOG]     — general info
[SUCCESS] — successful operations
[ERROR]   — validation failures
[WARNING] — non-critical alerts
```

### `Customer`
Holds customer identity. Email can be updated via `UpdateEmail()` — all other properties are immutable after creation.

### `BankAccount`
Core banking entity. Balance is protected — can only increase via `Deposit()` or decrease via `Withdraw()`. Both methods validate input before executing.

### `Transaction`
Pure data class. Records what happened, when, and on which account. No behaviour — only state.

### `Bank`
Top-level orchestrator. Owns lists of all customers, accounts and transactions. Exposes methods to add entities and print system-wide reports.

---

## Sample Output

```
[LOG] Zenith Bank banking system initialised.
[LOG] Customer Babatunde Ogunmola created successfully.
[LOG] Account 0023291889 opened for Babatunde Ogunmola
[SUCCESS] Deposit of ₦2,000.00 successful. New balance: ₦2,000.00
[ERROR] Insufficient funds.

===== ALL ACCOUNTS =====
Account No   : 0023291889
Account Type : Current
Owner        : Babatunde Ogunmola
Balance      : ₦2,000.00
Date Opened  : 31/07/2026
Status       : Active
=========================
```

---

## How to Run

**Prerequisites:** .NET 10 SDK — [download here](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/bbmattieu9/BankCore.git
cd BankCore
dotnet run
```

---

## Roadmap

- [ ] `IdGenerator` — auto-generate unique account numbers and customer IDs
- [ ] `ProcessTransaction()` — unify deposit/withdrawal with transaction recording
- [ ] Inheritance — `SavingsAccount` and `CurrentAccount` extending `BankAccount`
- [ ] Interface — `IAccount` contract for polymorphism
- [ ] Unit tests with xUnit

---

## Author

**Babatunde Ogunmola** — Frontend Engineer transitioning to full-stack .NET development.
6 years banking domain experience across Sterling Bank and Zenith Bank.

---

*Part of a structured learning path: C# Basics → OOP → ASP.NET Core API → AI Engineering*