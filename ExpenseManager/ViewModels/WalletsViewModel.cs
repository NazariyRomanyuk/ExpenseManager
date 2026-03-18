using System.Collections.ObjectModel;
using ExpenseManager.DTOModels;
using ExpenseManager.Services;
using ExpenseManager.Pages;

namespace ExpenseManager.ViewModels;

public class WalletsViewModel
{
    private readonly IService _service;
    public ObservableCollection<WalletDto> Wallets { get; set; }
    public WalletDto CurrentWallet { get; set; }
    public Command WalletSelected { get; }

    public WalletsViewModel(IService service)
    {
        _service = service;
        Wallets = new ObservableCollection<WalletDto>(_service.GetAllWallets());
        WalletSelected = new Command(LoadWallet);
    }
    private void LoadWallet() {
        if (CurrentWallet != null) 
            Shell.Current.GoToAsync($"{nameof(WalletDetailsPage)}", new Dictionary<string, object>{{"WalletId", CurrentWallet.Id}});
    }
}