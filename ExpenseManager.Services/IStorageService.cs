using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public interface IStorageService
{
    public IEnumerable<TransactionDbModel> GetTransactions(Guid walletId);
    public IEnumerable<WalletDbModel> GetAllWallets();
    public TransactionDbModel? GetTransaction(Guid transactionId);
    public WalletDbModel? GetWallet(Guid walletId);
}