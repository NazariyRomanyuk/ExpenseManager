using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class WalletEditViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IService _service;
    private Guid _walletId;
    private Currency _currency;

    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial string OwnerFirstName { get; set; }

    [ObservableProperty]
    public partial string OwnerLastName { get; set; }

    [ObservableProperty]
    public partial Dictionary<string, string> Errors { get; set; }

    public WalletEditViewModel(IService service)
    {
        _service = service;
        Errors = InitErrors();
    }
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var wallet = (WalletDetailsDTO)query["Wallet"];
        _walletId = wallet.Id;
        Name = wallet.Name;
        _currency = wallet.Currency;
        OwnerFirstName = wallet.OwnerFirstName;
        OwnerLastName = wallet.OwnerLastName;
    }
    
    [RelayCommand]
    private async Task EditWallet()
    {
        IsBusy = true;
        var errors = Validators.ValidateWallet(Name, _currency, OwnerFirstName, OwnerLastName);
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
            var wallet = new WalletEditDTO(_walletId, Name, _currency, OwnerFirstName, OwnerLastName);
            await _service.UpdateWalletAsync(wallet);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to update wallet: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoBack()
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
            { nameof(Name), string.Empty },
            { nameof(Currency), string.Empty },
            { nameof(OwnerFirstName), string.Empty },
            { nameof(OwnerLastName), string.Empty },
        };
    }

  
}