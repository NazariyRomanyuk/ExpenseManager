using ExpenseManager.Pages;

namespace ExpenseManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute($"{nameof(WalletDetailsPage)}", typeof(WalletDetailsPage));
        Routing.RegisterRoute($"{nameof(TransactionDetailsPage)}", typeof(TransactionDetailsPage));
        Routing.RegisterRoute($"{nameof(TransactionCreatePage)}", typeof(TransactionCreatePage));
    }
}