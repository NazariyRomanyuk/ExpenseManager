using System.Collections.ObjectModel;
using ExpenseManager.DTOModels;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public class WalletsViewModel
{
    private readonly IService _service;
    public ObservableCollection<WalletListDto> Wallets { get; set; }

    public WalletsViewModel(IService service)
    {
        _service = service;
        Wallets = new ObservableCollection<WalletListDto>(_service.GetAllWallets());
    }
    private void LoadWallet() {
        // var wallet = (WalletUiViewModel)e.CurrentSelection[0];
        // Shell.Current.GoToAsync($"{nameof(WalletDetailsPage)}", new Dictionary<string, object>{{"SelectedWallet", wallet}});
    }
}