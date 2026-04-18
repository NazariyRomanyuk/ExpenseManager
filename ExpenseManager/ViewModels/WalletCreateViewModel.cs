using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class WalletCreateViewModel : BaseViewModel
{
    private readonly IService _service;

    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial EnumWithName<Currency>? Currency { get; set; }

    [ObservableProperty]
    public partial string OwnerFirstName { get; set; }

    [ObservableProperty]
    public partial string OwnerLastName { get; set; }

    [ObservableProperty]
    public partial Dictionary<string, string> Errors { get; set; }
    public EnumWithName<Currency>[] Currencies { get; }

    public WalletCreateViewModel(IService service)
    {
        _service = service;
        Currencies = EnumExtensions.GetValuesWithNames<Currency>();
        Errors = InitErrors();
    }
    
    [RelayCommand]
    private async Task CreateWallet()
    {
        IsBusy = true;
        var errors = Validators.ValidateWallet(Name, Currency?.Value, OwnerFirstName, OwnerLastName);
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
            var wallet = new WalletCreateDTO(Name, Currency.Value, OwnerFirstName, OwnerLastName);
            await _service.CreateWalletAsync(wallet);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to create wallet: {e.Message}", "OK");
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
            { nameof(Name), string.Empty },
            { nameof(Currency), string.Empty },
            { nameof(OwnerFirstName), string.Empty },
            { nameof(OwnerLastName), string.Empty },
        };
    }
    
}