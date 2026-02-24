using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Services;
using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletsPage : ContentPage
{
    private StorageService _storageService;
    public ObservableCollection<WalletUiViewModel> Wallets { get; set; }
    public WalletsPage(StorageService storageService)
    {
        InitializeComponent();
        _storageService = storageService;
        Wallets = new ObservableCollection<WalletUiViewModel>();
        foreach (var wallet in _storageService.GetAllWallets())
        {
            Wallets.Add(new WalletUiViewModel(_storageService, wallet));
        }
        BindingContext = this;
    }
}