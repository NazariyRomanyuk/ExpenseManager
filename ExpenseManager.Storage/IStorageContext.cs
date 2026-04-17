using ExpenseManager.DBModels;

namespace ExpenseManager.Storage;

public interface IStorageContext
{
    IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId);
    IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync();
    Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId);
    Task<WalletDBModel?> GetWalletAsync(Guid walletId);
    Task<decimal> GetAmountForWalletAsync(Guid walletId);
}