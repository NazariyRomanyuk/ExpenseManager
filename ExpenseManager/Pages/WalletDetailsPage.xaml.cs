using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Services;
using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentWallet), "SelectedWallet")]
public partial class WalletDetailsPage : ContentPage
{
    private IStorageService _storageService;
    private WalletUiViewModel _currentWallet;

    public WalletUiViewModel CurrentWallet
    {
        get => _currentWallet;
        set
        {
            _currentWallet = value;
            _currentWallet.LoadTransactions();
            BindingContext = CurrentWallet;
        }
    }

    public WalletDetailsPage(IStorageService storageService)
    {
        InitializeComponent();
        _storageService = storageService;
    }

    private void TransactionSelected(object? sender, SelectionChangedEventArgs e)
    {
        var transaction = (TransactionUiViewModel)e.CurrentSelection[0];
        Shell.Current.GoToAsync($"{nameof(TransactionDetailsPage)}", new Dictionary<string, object>{{"SelectedTransaction", transaction}});
    }
}