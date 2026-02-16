using ExpenseManager.Common;

namespace ExpenseManager.DBModels;

public class WalletDBModel
{
    public Guid Id { get; }
    public string Name { get; set; }
    public WalletCurrency Currency { get; set; }

    public WalletDBModel(string name, WalletCurrency currency)
    {
        Id = Guid.NewGuid();
        Name = name;
        Currency = currency;
    }
}