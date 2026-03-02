namespace ExpenseManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("WalletsPage/WalletDetails", typeof(Pages.WalletDetailsPage));
    }
}