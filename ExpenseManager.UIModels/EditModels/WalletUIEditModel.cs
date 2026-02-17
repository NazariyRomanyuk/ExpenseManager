using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels.EditModels;

public class WalletUIEditModel
{
    private WalletDBModel _dbModel;
    private string _name;
    private WalletCurrency _currency;
    private List<TransactionUIModel> _transactions;

    public Guid Id => _dbModel.Id;

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

    public WalletUIEditModel(WalletDBModel dbModel)
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
        _currency = dbModel.Currency;
    }
    
    public void SaveChangesToDbModel()
    {
        if (string.IsNullOrWhiteSpace(_name)) throw new ArgumentNullException(nameof(_name), "Name cannot be null or empty.");
        _dbModel.Name = _name;
        _dbModel.Currency = _currency;
    }
}