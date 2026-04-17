using System.Collections.ObjectModel;
using ExpenseManager.Services;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletsPage : ContentPage
{
    private WalletsViewModel _viewModel;
    public WalletsPage(WalletsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    protected override async void OnAppearing()
    {
        await _viewModel.Refresh();
    }
}