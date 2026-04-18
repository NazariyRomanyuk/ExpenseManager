using ExpenseManager.DBModels;
using ExpenseManager.Storage;

namespace LecturerManager.Repository;

public class Repository : IRepository
{
    private readonly IStorageContext _storageContext;
    public Repository(IStorageContext storageContext)
    {
        _storageContext = storageContext;
    }
    public IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync()
    {
        return _storageContext.GetAllWalletsAsync();
    }

    public IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId)
    {
        return _storageContext.GetTransactionsAsync(walletId);
    }

    public Task<WalletDBModel?> GetWalletAsync(Guid walletId)
    {
        return _storageContext.GetWalletAsync(walletId);
    }

    public Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId)
    {
        return _storageContext.GetTransactionAsync(transactionId);
    }

    public Task<decimal> GetAmountForWalletAsync(Guid walletId)
    {
        return _storageContext.GetAmountForWalletAsync(walletId);
    }
    
    // Return or async???

    public Task AddWalletAsync(WalletDBModel wallet)
    {
        return _storageContext.AddWalletAsync(wallet);
    }

    public Task UpdateWalletAsync(WalletDBModel wallet)
    {
        return _storageContext.UpdateWalletAsync(wallet);
    }

    public Task DeleteWalletAsync(Guid walletId)
    {
        return _storageContext.DeleteWalletAsync(walletId);
    }

    public Task AddTransactionAsync(TransactionDBModel transaction)
    {
        return _storageContext.AddTransactionAsync(transaction);
    }

    public Task UpdateTransactionAsync(TransactionDBModel transaction)
    {
        return _storageContext.UpdateTransactionAsync(transaction);
    }

    public Task DeleteTransactionAsync(Guid transactionId)
    {
        return _storageContext.DeleteTransactionAsync(transactionId);
    }
}