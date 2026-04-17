using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;

namespace ExpenseManager.Storage;

public class InMemoryStorageContext : IStorageContext
{
    private record WalletRecord(Guid Id, string Name, Currency Currency, string OwnerFirstName, string OwnerLastName);
    private record TransactionRecord(Guid Id, Guid WalletId, decimal Amount, PaymentCategory PaymentCategory, string Description, DateTime Date);

    private static readonly List<WalletRecord> _wallets = new();
    private static readonly List<TransactionRecord> _transactions = new();

    static InMemoryStorageContext()
    {
        var uahWallet = new WalletRecord(Guid.NewGuid(),"Hryvnia Wallet", Currency.Uah, "Nazariy", "Romanyuk");
        var usdWallet = new WalletRecord(Guid.NewGuid(),"Dollar Wallet", Currency.Usd, "Kevin", "Mackelroy");
        var eurWallet = new WalletRecord(Guid.NewGuid(),"Euro Wallet", Currency.Eur, "Erik", "Svensson");
        _wallets.Add(uahWallet);
        _wallets.Add(usdWallet);
        _wallets.Add(eurWallet);

        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, 10000m, PaymentCategory.Crediting,
            "Salary for October 2025", new DateTime(2025, 10, 01, 02, 30, 11)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -2100m, PaymentCategory.Shopping,
            "LC Waikiki payment", new DateTime(2025, 10, 06, 19, 11, 20)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -384.57m,
            PaymentCategory.AutomobileServices, "OKKO gas payment", new DateTime(2025, 10, 14, 07, 45, 14)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -231.19m, PaymentCategory.OnlineServices,
            "Google One payment", new DateTime(2025, 10, 28, 20, 00, 00)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, 12000m, PaymentCategory.Crediting,
            "Salary for November 2025", new DateTime(2025, 11, 01, 02, 30, 11)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -247.2m, PaymentCategory.Taxi,
            "Uklon payment", new DateTime(2025, 11, 15, 14, 23, 54)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -399.9m, PaymentCategory.FoodAndBeverage,
            "ATB payment", new DateTime(2025, 11, 22, 17, 02, 04)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -10m, PaymentCategory.OnlineServices,
            "Google Play payment", new DateTime(2025, 12, 25, 12, 25, 12)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -200m, PaymentCategory.Entertainment,
            "Steam Wallet payment", new DateTime(2026, 01, 05, 20, 04, 30)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), uahWallet.Id, -76.99m, PaymentCategory.FoodAndBeverage,
            "Silpo market payment", new DateTime(2026, 02, 13, 15, 10, 59)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), usdWallet.Id, 1000m, PaymentCategory.Crediting,
            "Salary for February 2026", new DateTime(2026, 02, 01, 00, 00, 00)));
        _transactions.Add(new TransactionRecord(Guid.NewGuid(), usdWallet.Id, -199.99m, PaymentCategory.Shopping,
            "Geox payment", new DateTime(2026, 02, 05, 17, 38, 10)));
    }
    public async IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId)
    {
        foreach (var transaction in _transactions)
        {
            await Task.Delay(100);
            if (transaction.WalletId == walletId) 
                yield return new TransactionDBModel(transaction.Id, transaction.WalletId, transaction.Amount, 
                    transaction.PaymentCategory, transaction.Description, transaction.Date);
        }
    }

    public async IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync()
    {
        await Task.Delay(100);
        foreach (var wallet in _wallets)
            yield return new WalletDBModel(wallet.Id, wallet.Name, wallet.Currency, wallet.OwnerFirstName,  wallet.OwnerLastName);
    }
    
    public Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId)
    {
        return Task.Run(() =>
        {
            var transaction = _transactions.FirstOrDefault(w => w.Id == transactionId);
            return transaction is null
                ? null
                : new TransactionDBModel(transaction.Id, transaction.WalletId, transaction.Amount,
                    transaction.PaymentCategory, transaction.Description, transaction.Date);
        });
    }

    public Task<WalletDBModel?> GetWalletAsync(Guid walletId)
    {
        return Task.Run(() =>
        {
            var wallet = _wallets.FirstOrDefault(w => w.Id == walletId);
            return wallet is null
                ? null
                : new WalletDBModel(wallet.Id, wallet.Name, wallet.Currency, wallet.OwnerFirstName,
                    wallet.OwnerLastName);
        });
    }

    public Task<decimal> GetAmountForWalletAsync(Guid walletId)
    {
        return Task.Run(() =>
        {
            return _transactions.Where(transaction => transaction.WalletId == walletId)
                .Sum(transaction => transaction.Amount);
        });
    }

    public Task AddWalletAsync(WalletDBModel wallet)
    {
        throw new NotImplementedException();
    }

    public Task DeleteWalletAsync(Guid walletId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateWalletAsync(WalletDBModel wallet)
    {
        throw new NotImplementedException();
    }

    public Task AddTransactionAsync(TransactionDBModel transaction)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTransactionAsync(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTransactionAsync(TransactionDBModel transaction)
    {
        throw new NotImplementedException();
    }
}