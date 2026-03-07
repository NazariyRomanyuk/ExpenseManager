using ExpenseManager.Services;
using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentWallet), "SelectedWallet")]
public partial class WalletDetailsPage : ContentPage
{
    private WalletUiViewModel _currentWallet = null!;

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
    }

    private void TransactionSelected(object? sender, SelectionChangedEventArgs e)
    {
        var transaction = (TransactionUiViewModel)e.CurrentSelection[0];
        Shell.Current.GoToAsync($"{nameof(TransactionDetailsPage)}", new Dictionary<string, object>{{"SelectedTransaction", transaction}});
    }
}