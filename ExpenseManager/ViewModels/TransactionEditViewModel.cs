using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class TransactionEditViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IService _service;
    private Guid _transactionId;
    private Guid _walletId;
    private DateTime _date;

    [ObservableProperty] 
    public partial decimal Amount { get; set; }
    [ObservableProperty] 
    public partial EnumWithName<PaymentCategory>? PaymentCategory { get; set; }
    [ObservableProperty] 
    public partial string Description { get; set; } = string.Empty;

    [ObservableProperty]
    public partial Dictionary<string, string> Errors { get; set; }

    public EnumWithName<PaymentCategory>[] PaymentCategories { get; }

    public TransactionEditViewModel(IService service)
    {
        _service = service;
        PaymentCategories = EnumExtensions.GetValuesWithNames<PaymentCategory>();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var transaction = (TransactionDetailsDTO)query["Transaction"];
        _transactionId = transaction.Id;
        _walletId = (Guid)query[nameof(TransactionEditDTO.WalletId)];
        Amount = transaction.Amount;
        _date = transaction.Date;
        Description = transaction.Description;
        PaymentCategory = PaymentCategories.FirstOrDefault(p => p.Value == transaction.PaymentCategory);
    }

    [RelayCommand]
    public async Task EditTransaction()
    {
        IsBusy = true;
        
        var errors = Validators.ValidateTransaction(Amount, PaymentCategory?.Value, Description, _date);
        Errors = InitErrors();
        if (errors.Count > 0)
        {
            foreach (var error in errors)
            {
                if (string.IsNullOrWhiteSpace(Errors[error.PropertyName]))
                {
                    Errors[error.PropertyName] = error.ErrorMessage;
                    continue;
                }
                Errors[error.PropertyName] += Environment.NewLine + error.ErrorMessage;
            }
            OnPropertyChanged(nameof(Errors));
            IsBusy = false;
            return;
        }

        try
        {
            var dto = new TransactionEditDTO(_transactionId, _walletId, Amount, PaymentCategory!.Value, Description, _date);
            await _service.UpdateTransactionAsync(dto);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to update transaction: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task GoBack()
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
    }
    
    private Dictionary<string, string> InitErrors()
    {
        return new Dictionary<string, string>()
        {
            { nameof(Amount), string.Empty },
            { nameof(PaymentCategory), string.Empty },
            { nameof(Description), string.Empty },
            { nameof(DateTime), string.Empty },
        };
    }
}