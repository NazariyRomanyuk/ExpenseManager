using ExpenseManager.Common;
using ExpenseManager.Common.Enums;

namespace ExpenseManager.DBModels;

public class WalletDbModel
{
    // Id is only set once during creation.
    public Guid Id { get; }
    // Name modifiable due to possible mistakes/changes.
    public string Name { get; set; }
    // Currency not modifiable due to breaking wallet sum calculation logic for transactions with different currencies.
    public Currency Currency { get; }
    public string OwnerFirstAndLastName { get; set; }

    public WalletDbModel(string name, Currency currency, string ownerFirstAndLastName) : this(Guid.NewGuid(), name, currency,  ownerFirstAndLastName) {}
    public WalletDbModel(Guid id, string name, Currency currency, string ownerFirstAndLastName)
    {
        Id = id;
        Name = name;
        Currency = currency;
        OwnerFirstAndLastName = ownerFirstAndLastName;
    }
}