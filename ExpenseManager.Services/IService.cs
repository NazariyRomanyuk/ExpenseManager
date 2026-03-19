using ExpenseManager.DBModels;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;

namespace ExpenseManager.Services;

public interface IService
{
    IEnumerable<WalletListDto> GetAllWallets();
    WalletDetailsDto GetWallet(Guid walletId);
    IEnumerable<TransactionListDto> GetTransactions(Guid walletId);
    
}