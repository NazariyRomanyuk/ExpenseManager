using ExpenseManager.Common;

namespace ExpenseManager.DBModels;

public class WalletDBModel
{
    public Guid Id { get; }
    public string Name { get; set; }
    public Currency Currency { get; }

    public WalletDBModel(string name, Currency currency)
    {
        Id = Guid.NewGuid();
        Name = name;
        Currency = currency;
    }
}