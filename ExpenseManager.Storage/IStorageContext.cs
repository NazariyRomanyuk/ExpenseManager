using ExpenseManager.DBModels;

namespace ExpenseManager.Storage;

public interface IStorageContext
{
    IEnumerable<TransactionDBModel> GetTransactions(Guid walletId);
    IEnumerable<WalletDBModel> GetAllWallets();
    TransactionDBModel? GetTransaction(Guid transactionId);
    WalletDBModel? GetWallet(Guid walletId);
    decimal GetAmountForWallet(Guid walletId);
}