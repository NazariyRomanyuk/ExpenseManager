namespace ExpenseManager.UIModels.CreateModels;

using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

public class WalletUICreateModel
{
    private string _name;
    private WalletCurrency _currency;
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public WalletCurrency Currency
    {
        get => _currency;
        set => _currency = value;
    }

    public WalletUICreateModel()
    {
  
    }

    public WalletDBModel CreateDBModel()
    {
        if (string.IsNullOrWhiteSpace(_name)) throw new ArgumentNullException(nameof(_name) , "Name cannot be null or empty.");
        return new WalletDBModel(_name, _currency);
    }
}