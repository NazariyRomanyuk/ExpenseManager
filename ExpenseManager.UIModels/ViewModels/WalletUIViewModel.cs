using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels.ViewModels;

public class WalletUIViewModel : INotifyPropertyChanged
{
    private readonly IStorageService _storageService;
    private readonly WalletDBModel _dbModel;
    // Transaction list nullable for being able to keep track of unloaded state.
    private List<TransactionUIViewModel>? _transactions;

    // Properties only have getters - view model has no access to setting.
    public Guid Id => _dbModel.Id;
    public string Name => _dbModel.Name;
    public Currency Currency => _dbModel.Currency;
    public IReadOnlyList<TransactionUIViewModel>? Transactions => _transactions;

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

    public WalletUIViewModel(IStorageService storageService, WalletDBModel dbModel)
    {
        _storageService = storageService;
        _dbModel = dbModel;
        _transactions = null;
    }

    public void LoadTransactions()
    {
        if (_transactions != null) return;
        _transactions = new List<TransactionUIViewModel>();
        foreach (var transaction in _storageService.GetTransactions(Id))
        {
            _transactions.Add(new TransactionUIViewModel(transaction, Currency, Name));
        }
        OnPropertyChanged(nameof(SumDescription));
    }
    public override string ToString()
    {
        return $"Name: {Name}, Currency: {Currency}, Amount: {SumDescription}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}