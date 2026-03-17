using ExpenseManager.DBModels;

namespace ExpenseManager.Storage;

public interface IStorageContext
{
    IEnumerable<TransactionDbModel> GetTransactions(Guid walletId);
    IEnumerable<WalletDbModel> GetAllWallets();
    TransactionDbModel GetTransaction(Guid transactionId);
    WalletDbModel GetWallet(Guid walletId);
}