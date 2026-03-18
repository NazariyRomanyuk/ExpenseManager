using ExpenseManager.DBModels;
using ExpenseManager.DTOModels;

namespace ExpenseManager.Services;

public interface IService
{
    IEnumerable<WalletDto> GetAllWallets();
    WalletDto GetWallet(Guid walletId);
    
}