using ExpenseManager.DBModels;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;

namespace ExpenseManager.Services;

public interface IService
{
    IEnumerable<WalletListDTO> GetAllWallets();
    WalletDetailsDTO GetWallet(Guid walletId);
    IEnumerable<TransactionListDTO> GetTransactions(Guid walletId);
    
}