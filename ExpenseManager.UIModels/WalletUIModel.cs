using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

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

    public void SaveChangesToDBModel()
    {
        if (_dbModel != null)
        {
            _dbModel.Name = _name;
            _dbModel.Currency = _currency;
        }
        else
        {
            _dbModel = new WalletDBModel(_name, _currency);
        }
    }

    public void LoadTransactions(StorageService storageService)
    {
        if (Id == null || _transactions.Count > 0) return;
        foreach (var transaction in storageService.GetTransactions(Id.Value))
        {
            _transactions.Add(new TransactionUIModel(transaction));
        }
    }

    public override string ToString()
    {
        return $"Name: {Name}, Currency: {Currency}, Amount: {WalletSum}";
    }
}