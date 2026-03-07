using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManager.Pages;

[QueryProperty(nameof(CurrentTransaction), "SelectedTransaction")]
public partial class TransactionDetailsPage : ContentPage
{
    private TransactionUiViewModel _currentTransaction = null!;

    public TransactionUiViewModel CurrentTransaction
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