using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class TransactionDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IService _service;
    private TransactionDetailsDTO _currentTransaction;
    // TODO: nullable?
    public decimal Amount => _currentTransaction.Amount;
    public Currency Currency => _currentTransaction.Currency;
    public PaymentCategory PaymentCategory => _currentTransaction.PaymentCategory;
    public string Description => _currentTransaction.Description;
    public DateTime Date => _currentTransaction.Date;
    public bool IsExpense => Amount < 0;
    public string WalletName => _currentTransaction.WalletName;

    public TransactionDetailsViewModel(IService service)
    {
        _service = service;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var transactionId = (Guid) query["transactionId"];
        _currentTransaction = _service.GetTransaction(transactionId);
        OnPropertyChanged(nameof(Amount));
        OnPropertyChanged(nameof(Currency));
        OnPropertyChanged(nameof(PaymentCategory));
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(IsExpense));
        OnPropertyChanged(nameof(WalletName));
    }
}