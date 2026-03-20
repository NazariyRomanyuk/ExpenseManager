using System.Collections.ObjectModel;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Services;
using ExpenseManager.Pages;

namespace ExpenseManager.ViewModels;

public class WalletsViewModel
{
    private readonly IService _service;
    public ObservableCollection<WalletListDTO> Wallets { get; set; }
    public WalletListDTO CurrentWallet { get; set; }
    public Command WalletSelected { get; }

    public WalletsViewModel(IService service)
    {
        _service = service;
        Wallets = new ObservableCollection<WalletListDTO>(_service.GetAllWallets());
        WalletSelected = new Command(LoadWallet);
    }
    
    private void LoadWallet()
    {
        Shell.Current.GoToAsync($"{nameof(WalletDetailsPage)}", new Dictionary<string, object>{{"WalletId", CurrentWallet.Id}});
    }
}