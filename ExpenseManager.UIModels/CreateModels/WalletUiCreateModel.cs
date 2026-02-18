namespace ExpenseManager.UIModels.CreateModels;

using ExpenseManager.Common;
using ExpenseManager.DBModels;

public class WalletUiCreateModel
{
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
    
    public WalletDbModel CreateDbModel()
    {
        if (string.IsNullOrWhiteSpace(_name)) throw new ArgumentException("Name cannot be null or empty.", nameof(_name));
        return new WalletDbModel(_name, _currency);
    }
}