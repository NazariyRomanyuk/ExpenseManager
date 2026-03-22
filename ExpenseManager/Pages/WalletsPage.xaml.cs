using System.Collections.ObjectModel;
using ExpenseManager.Services;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletsPage : ContentPage
{
    public WalletsPage(WalletsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}