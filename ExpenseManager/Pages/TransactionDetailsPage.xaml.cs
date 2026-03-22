using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class TransactionDetailsPage : ContentPage
{
    public TransactionDetailsPage(TransactionDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}