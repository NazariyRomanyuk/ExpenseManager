using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Pages;

public partial class WalletCreatePage : ContentPage
{
    public WalletCreatePage(WalletCreateViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}