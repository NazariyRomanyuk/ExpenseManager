using ExpenseManager.Common;

namespace ExpenseManager.DBModels;

public class WalletDbModel
{
    // Id is only set once during creation.
    public Guid Id { get; }
    // Name modifiable due to possible mistakes/changes.
    public string Name { get; set; }
    // Currency not modifiable due to breaking wallet sum calculation logic for transactions with different currencies.
    public Currency Currency { get; }

    public WalletDbModel(string name, Currency currency)
    {
        Id = Guid.NewGuid();
        Name = name;
        Currency = currency;
    }
}