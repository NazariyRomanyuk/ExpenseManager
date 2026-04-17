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

    internal async Task Refresh()
    {
        IsBusy = true;
        Wallets = new ObservableCollection<WalletListDTO>();
        await foreach (var wallet in _service.GetAllWalletsAsync())
            Wallets.Add(wallet);
        IsBusy = false;
    }
    
    [RelayCommand]
    private async Task LoadWallet()
    {
        IsBusy = true;
        await Shell.Current.GoToAsync($"{nameof(WalletDetailsPage)}", new Dictionary<string, object>{{"WalletId", CurrentWallet.Id}});
        IsBusy = false;
    }
}