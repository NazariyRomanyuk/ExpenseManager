using ExpenseManager.DBModels;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;

namespace ExpenseManager.Services;

public interface IService
{
    IAsyncEnumerable<WalletListDTO> GetAllWalletsAsync();
    Task<WalletDetailsDTO> GetWalletAsync(Guid walletId);
    IAsyncEnumerable<TransactionListDTO> GetTransactionsAsync(Guid walletId);
    Task<TransactionDetailsDTO> GetTransactionAsync(Guid transactionId);
    
}