using ExpenseManager.DBModels;

namespace LecturerManager.Repository;

public interface IRepository
{
    IEnumerable<WalletDbModel> GetAllWallets();
    IEnumerable<TransactionDbModel> GetTransactions(Guid walletId);
    WalletDbModel GetWallet(Guid walletId);
    TransactionDbModel GetTransaction(Guid transactionId);
    decimal GetAmountForWallet(Guid walletId);
}