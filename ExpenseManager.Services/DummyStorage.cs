using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

internal static class DummyStorage
{
    private static readonly List<WalletDbModel> _wallets;
    private static readonly List<TransactionDbModel> _transactions;
    
    internal static IEnumerable<WalletDbModel> Wallets => _wallets;
    internal static IEnumerable<TransactionDbModel> Transactions => _transactions;

    static DummyStorage()
    {
        var uahWallet = new WalletDbModel("Hryvnia Wallet", Currency.Uah);
        var usdWallet = new WalletDbModel("Dollar Wallet", Currency.Usd);
        var eurWallet = new WalletDbModel("Euro Wallet", Currency.Eur);
        _wallets = new List<WalletDbModel> { uahWallet, usdWallet, eurWallet };
        _transactions = new List<TransactionDbModel>()
        {
            new TransactionDbModel(uahWallet.Id, 10000m, PaymentCategory.Crediting, "Salary for October 2025", new DateTime(2025,10,01,02,30,11)),
            new TransactionDbModel(uahWallet.Id, -2100m, PaymentCategory.Shopping, "LC Waikiki payment", new DateTime(2025,10,06,19,11,20)),
            new TransactionDbModel(uahWallet.Id, -384.57m, PaymentCategory.AutomobileServices, "OKKO gas payment", new DateTime(2025,10,14,07,45,14)),
            new TransactionDbModel(uahWallet.Id, -231.19m, PaymentCategory.OnlineServices, "Google One payment", new DateTime(2025,10,28,20,00,00)),
            new TransactionDbModel(uahWallet.Id, 12000m, PaymentCategory.Crediting, "Salary for November 2025", new DateTime(2025,11,01,02,30,11)),
            new TransactionDbModel(uahWallet.Id, -247.2m, PaymentCategory.Taxi, "Uklon payment", new DateTime(2025,11,15,14,23,54)),
            new TransactionDbModel(uahWallet.Id, -399.9m, PaymentCategory.FoodAndBeverage, "ATB payment", new DateTime(2025,11,22,17,02,04)),
            new TransactionDbModel(uahWallet.Id, -10m, PaymentCategory.OnlineServices, "Google Play payment", new DateTime(2025,12,25,12,25,12)),
            new TransactionDbModel(uahWallet.Id, -200m, PaymentCategory.Entertainment, "Steam Wallet payment", new DateTime(2026,01,05,20,04,30)),
            new TransactionDbModel(uahWallet.Id, -76.99m, PaymentCategory.FoodAndBeverage, "Silpo market payment", new DateTime(2026,02,13,15,10,59)),
            new TransactionDbModel(usdWallet.Id, 1000m, PaymentCategory.Crediting, "Salary for February 2026", new DateTime(2026,02,01,00,00,00)),
            new TransactionDbModel(usdWallet.Id, -199.99m, PaymentCategory.Shopping, "Geox payment", new DateTime(2026,02,05,17,38,10))
        };

    }
    
}