using ExpenseManager.Services;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletDetailsPage : ContentPage
{
    public WalletDetailsPage(WalletDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}