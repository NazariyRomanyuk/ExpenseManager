using ExpenseManager.Services;
using ExpenseManager.UIModels.ViewModels;

namespace ExpenseManagerConsole;

internal class ConsoleApp
{
    private static StorageService _storageService;
    private static List<WalletUiViewModel> _wallets;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Expense Manager console app!");
        _storageService = new StorageService();
        LoadWallets();
        while (true)
        {
            Console.WriteLine("List of wallets:");
            foreach (var wallet in _wallets)
            {
                Console.WriteLine(wallet);
            }
            Console.WriteLine("To view the transactions for a specific wallet, enter the wallet name. To quit, enter \"quit\".");
            String walletName = Console.ReadLine();

            if (walletName == "quit")
            {
                Console.WriteLine("Quitting...");
                break;
            }
            WalletDetailsOutput(walletName);
        }
    }
    
    private static void WalletDetailsOutput(string? walletName)
    {
        bool walletExists = false;
        foreach (var wallet in _wallets)
        {
            if (wallet.Name == walletName)
            {
                walletExists = true;
                wallet.LoadTransactions(_storageService);
                Console.WriteLine($"Transactions in {wallet.Name}:");
                foreach (var transaction in wallet.Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
        if (!walletExists) Console.WriteLine("Wallet not found. Please try again.");
    }
    
    private static void LoadWallets()
    {
        if (_wallets != null) return;
        _wallets = new List<WalletUiViewModel>();
        foreach (var wallet in _storageService.GetWallets())
        {
            _wallets.Add(new WalletUiViewModel(wallet));
        }
    }
}