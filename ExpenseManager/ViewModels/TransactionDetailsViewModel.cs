using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseManager.Common.Enums;
using ExpenseManager.Common.Exceptions;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public class TransactionDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IService _service;
    private TransactionDetailsDTO _currentTransaction = null!;
    private Guid _id;
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
        _id = (Guid) query["transactionId"];
    }

    internal async Task Refresh()
    {
        IsBusy = true;
        try
        {
            _currentTransaction = await _service.GetTransactionAsync(_id);
            OnPropertyChanged(nameof(Amount));
            OnPropertyChanged(nameof(Currency));
            OnPropertyChanged(nameof(PaymentCategory));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(IsExpense));
            OnPropertyChanged(nameof(WalletName));
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
        
    }
}