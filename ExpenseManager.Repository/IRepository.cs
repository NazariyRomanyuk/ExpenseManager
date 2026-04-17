using ExpenseManager.DBModels;

namespace LecturerManager.Repository;

public interface IRepository
{
    IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync();
    IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId);
    Task<WalletDBModel?> GetWalletAsync(Guid walletId);
    Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId);
    Task<decimal> GetAmountForWalletAsync(Guid walletId);
}