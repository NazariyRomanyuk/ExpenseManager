using ExpenseManager.Common.Enums;

namespace ExpenseManager.UIModels.CreateModels;

using ExpenseManager.Common;
using ExpenseManager.DBModels;

public class WalletUiCreateModel
{
    // Initialized to suppress IntelliSense warnings about potential null reference types.
    private string _name = string.Empty;
    private Currency _currency;
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Currency Currency
    {
        get => _currency;
        set => _currency = value;
    }
    
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    
    public WalletDbModel CreateDbModel()
    {
        return new WalletDbModel(Guid.NewGuid(), _name, _currency, OwnerFirstName, OwnerLastName);
    }
}