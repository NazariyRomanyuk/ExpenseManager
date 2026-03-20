using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentTransaction), "SelectedTransaction")]
public partial class TransactionDetailsPage : ContentPage
{
    private TransactionUIViewModel _currentTransaction = null!;

    public TransactionUIViewModel CurrentTransaction
    {
        get => _currentTransaction;
        set
        {
            _currentTransaction = value;
            BindingContext = CurrentTransaction;
        }
    }

    public TransactionDetailsPage()
    {
        InitializeComponent();
    }
}