using ExpenseManager.DBModels;

namespace ExpenseManager.Storage;

public interface IStorageContext
{
    IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId);
    IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync();
    Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId);
    Task<WalletDBModel?> GetWalletAsync(Guid walletId);
    Task<decimal> GetAmountForWalletAsync(Guid walletId);
    Task AddWalletAsync(WalletDBModel wallet);
    Task DeleteWalletAsync(Guid walletId);
    Task UpdateWalletAsync(WalletDBModel wallet);
    Task AddTransactionAsync(TransactionDBModel transaction);
    Task DeleteTransactionAsync(Guid transactionId);
    Task UpdateTransactionAsync(TransactionDBModel transaction);
}