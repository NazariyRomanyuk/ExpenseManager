using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class TransactionCreateViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IService _service;
    private Guid _walletId;

    [ObservableProperty]
    public partial decimal Amount { get; set; }

    [ObservableProperty]
    public partial EnumWithName<PaymentCategory> PaymentCategory { get; set; }

    [ObservableProperty]
    public partial string Description { get; set; }

    [ObservableProperty]
    public partial DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [ObservableProperty]
    public partial TimeSpan Time { get; set; } = DateTime.Now.TimeOfDay;

    public DateTime DateTime => Date.ToDateTime(TimeOnly.FromTimeSpan(Time));

    [ObservableProperty]
    public partial Dictionary<string, string> Errors { get; set; }
    public EnumWithName<PaymentCategory>[] PaymentCategories { get; }

    public TransactionCreateViewModel(IService service)
    {
        _service = service;
        PaymentCategories = EnumExtensions.GetValuesWithNames<PaymentCategory>();
        Errors = InitErrors();
    }
    
    partial void OnDateChanged(DateOnly value) => OnPropertyChanged(nameof(DateTime));
    partial void OnTimeChanged(TimeSpan value) => OnPropertyChanged(nameof(DateTime));
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _walletId = (Guid)query[nameof(TransactionCreateDTO.WalletId)];
    }

    [RelayCommand]
    public async Task CreateTransaction()
    {
        IsBusy = true;
        var errors = Validators.ValidateTransaction(Amount, PaymentCategory?.Value, Description, DateTime);
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
            var transaction = new TransactionCreateDTO(_walletId, Amount, PaymentCategory.Value, Description, DateTime);
            await _service.CreateTransactionAsync(transaction);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to register transaction: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    public async Task GoBack()
    {
        IsBusy = true;
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to go back: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
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