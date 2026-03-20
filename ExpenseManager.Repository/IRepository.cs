using ExpenseManager.DBModels;

namespace LecturerManager.Repository;

public interface IRepository
{
    IEnumerable<WalletDBModel> GetAllWallets();
    IEnumerable<TransactionDBModel> GetTransactions(Guid walletId);
    WalletDBModel GetWallet(Guid walletId);
    TransactionDBModel GetTransaction(Guid transactionId);
    decimal GetAmountForWallet(Guid walletId);
}