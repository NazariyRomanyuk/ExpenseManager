using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

internal static class DummyStorage
{
    private static readonly List<WalletDBModel> _wallets;
    private static readonly List<TransactionDBModel> _transactions;
    
    internal static IEnumerable<WalletDBModel> Wallets => _wallets;
    internal static IEnumerable<TransactionDBModel> Transactions => _transactions;

    static DummyStorage()
    {
        var uahWallet = new WalletDBModel("Hryvnia Wallet", Currency.UAH);
        var usdWallet = new WalletDBModel("Dollar Wallet", Currency.USD);
        var eurWallet = new WalletDBModel("Euro Wallet", Currency.EUR);
        _wallets = new List<WalletDBModel> { uahWallet, usdWallet, eurWallet };
        _transactions = new List<TransactionDBModel>()
        {
            new TransactionDBModel(uahWallet.Id, 10000m, PaymentCategory.Crediting, "Salary for October 2025", new DateTime(2025,10,01,02,30,11)),
            new TransactionDBModel(uahWallet.Id, -2100m, PaymentCategory.Shopping, "LC Waikiki payment", new DateTime(2025,10,06,19,11,20)),
            new TransactionDBModel(uahWallet.Id, -384.57m, PaymentCategory.AutomobileServices, "OKKO gas payment", new DateTime(2025,10,14,07,45,14)),
            new TransactionDBModel(uahWallet.Id, -231.19m, PaymentCategory.OnlineServices, "Google One payment", new DateTime(2025,10,28,20,00,00)),
            new TransactionDBModel(uahWallet.Id, 12000m, PaymentCategory.Crediting, "Salary for November 2025", new DateTime(2025,11,01,02,30,11)),
            new TransactionDBModel(uahWallet.Id, -247.2m, PaymentCategory.Taxi, "Uklon payment", new DateTime(2025,11,15,14,23,54)),
            new TransactionDBModel(uahWallet.Id, -399.9m, PaymentCategory.FoodAndBeverage, "ATB payment", new DateTime(2025,11,22,17,02,04)),
            new TransactionDBModel(uahWallet.Id, -10m, PaymentCategory.OnlineServices, "Google Play payment", new DateTime(2025,12,25,12,25,12)),
            new TransactionDBModel(uahWallet.Id, -200m, PaymentCategory.Entertainment, "Steam Wallet payment", new DateTime(2026,01,05,20,04,30)),
            new TransactionDBModel(uahWallet.Id, -76.99m, PaymentCategory.FoodAndBeverage, "Silpo market payment", new DateTime(2026,02,13,15,10,59)),
            new TransactionDBModel(usdWallet.Id, 1000m, PaymentCategory.Crediting, "Salary for February 2026", new DateTime(2026,02,01,00,00,00)),
            new TransactionDBModel(usdWallet.Id, -199.99m, PaymentCategory.Shopping, "Geox payment", new DateTime(2026,02,05,17,38,10))
        };

    }
    
}