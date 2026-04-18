using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;
using ExpenseManager.Pages;

namespace ExpenseManager.ViewModels;

public partial class WalletsViewModel : BaseViewModel
{
    private readonly IService _service;

    [ObservableProperty]
    public partial ObservableCollection<WalletListDTO> Wallets { get; set; }

    [ObservableProperty]
    public partial WalletListDTO CurrentWallet { get; set; }

    public WalletsViewModel(IService service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task Refresh()
    {
        IsBusy = true;
        try
        {
            Wallets = new ObservableCollection<WalletListDTO>();
            await foreach (var wallet in _service.GetAllWalletsAsync())
                Wallets.Add(wallet);
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
    
    [RelayCommand]
    private async Task LoadWallet()
    {
        IsBusy = true;
        try
        {
            await Shell.Current.GoToAsync($"{nameof(WalletDetailsPage)}",
                new Dictionary<string, object> { { "WalletId", CurrentWallet.Id } });
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to load wallet details: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
        
    }

    [RelayCommand]
    private async Task AddWallet()
    {
        IsBusy = true;
        try
        {
            await Shell.Current.GoToAsync($"{nameof(WalletCreatePage)}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to wallet create page: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task DeleteWallet(WalletListDTO wallet)
    {
        IsBusy = true;
        try
        {
            if (await Shell.Current.DisplayAlertAsync("Confirm", "Are you sure you want to delete this wallet?",
                    "Yes", "No"))
            {
                await _service.DeleteWalletAsync(wallet.Id);
                Wallets.Remove(wallet);
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to delete wallet: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task EditWallet(WalletListDTO wallet)
    {
        IsBusy = true;
        try
        {
            var details = await _service.GetWalletAsync(wallet.Id);
            await Shell.Current.GoToAsync($"{nameof(WalletEditPage)}", 
                new Dictionary<string, object> { { "Wallet", details }});
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to wallet edit page: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}