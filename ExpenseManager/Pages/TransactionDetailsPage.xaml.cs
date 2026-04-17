using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class TransactionDetailsPage : ContentPage
{
    private readonly TransactionDetailsViewModel _viewModel;
    public TransactionDetailsPage(TransactionDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        await _viewModel.Refresh();
    }
}