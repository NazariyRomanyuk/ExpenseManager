using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels.ViewModels;

public class WalletUiViewModel
{
    private readonly WalletDbModel _dbModel;
    // Transaction list nullable for being able to keep track of unloaded state.
    private List<TransactionUiViewModel>? _transactions;

    // Properties only have getters - view model has no access to setting.
    public Guid Id => _dbModel.Id;
    public string Name => _dbModel.Name;
    public Currency Currency => _dbModel.Currency;
    public IReadOnlyList<TransactionUiViewModel>? Transactions => _transactions;

    public decimal? WalletSum => _transactions?.Sum(t => t.Amount);

    // Separate readable output for unloaded state, empty wallet and wallet with transactions.
    public string SumDescription
    {
        get
        {
            if (_transactions == null) return "not loaded";
            if (_transactions.Count == 0) return "0";
            return $"{_transactions.Sum(t => t.Amount)}";
        }
    } 

    public WalletUiViewModel(WalletDbModel dbModel)
    {
        _dbModel = dbModel;
        _transactions = null;
    }

    public void LoadTransactions(StorageService storageService)
    {
        if (_transactions != null) return;
        _transactions = new List<TransactionUiViewModel>();
        foreach (var transaction in storageService.GetTransactions(Id))
        {
            _transactions.Add(new TransactionUiViewModel(transaction, Currency));
        }
    }
    public override string ToString()
    {
        return $"Name: {Name}, Currency: {Currency}, Amount: {SumDescription}";
    }
}