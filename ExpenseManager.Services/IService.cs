using ExpenseManager.DBModels;
using ExpenseManager.DTOModels;

namespace ExpenseManager.Services;

public interface IService
{
    public IEnumerable<WalletListDto> GetAllWallets();
}