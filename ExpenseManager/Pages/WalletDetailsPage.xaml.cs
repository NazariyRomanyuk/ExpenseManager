using ExpenseManager.Services;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletDetailsPage : ContentPage
{
    private WalletDetailsViewModel _viewModel;
    public WalletDetailsPage(WalletDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    protected override async void OnAppearing()
    {
        await _viewModel.Refresh();
    }
}