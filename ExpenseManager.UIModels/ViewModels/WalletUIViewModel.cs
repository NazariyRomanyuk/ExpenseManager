using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels.ViewModels;

public class WalletUIViewModel
{
    private WalletDBModel _dbModel;
    private List<TransactionUIModel> _transactions;

    public Guid Id => _dbModel.Id;
    public string Name => _dbModel.Name;
    public WalletCurrency Currency => _dbModel.Currency;
    public IReadOnlyList<TransactionUIModel> Transactions => _transactions;

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

    public WalletUIViewModel(WalletDBModel dbModel)
    {
        _dbModel = dbModel;
        _transactions = new List<TransactionUIModel>();
    }

    public void LoadTransactions(StorageService storageService)
    {
        if (_transactions.Count > 0) return;
        foreach (var transaction in storageService.GetTransactions(Id))
        {
            _transactions.Add(new TransactionUIModel(transaction));
        }
    }
    public override string ToString()
    {
        return $"Name: {Name}, Currency: {Currency}, Amount: {WalletSum}";
    }
}