using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels;

public class WalletUIModel
{
    private WalletDBModel _dbModel;
    private string _name;
    private WalletCurrency _currency;
    private List<TransactionUIModel> _transactions;

    public Guid? Id
    {
        get => _dbModel?.Id;
    }

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

    public IReadOnlyList<TransactionUIModel> Transactions
    {
        get => _transactions;
    }

    public decimal WalletSum
    {
        get
        {
            decimal sum = 0;
            foreach (var transaction in _transactions)
            {
                sum += transaction.Amount;
            }
            return sum;
        }
    }

    public WalletUIModel()
    {
        _transactions = new List<TransactionUIModel>();
    }
    
    public WalletUIModel(WalletDBModel dbModel):this()
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
        _currency = dbModel.Currency;
    }
    
}