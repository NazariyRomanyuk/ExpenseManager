using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public interface IStorageService
{
    public IEnumerable<TransactionDBModel> GetTransactions(Guid walletId);
    public IEnumerable<WalletDBModel> GetAllWallets();
    public TransactionDBModel? GetTransaction(Guid transactionId);
    public WalletDBModel? GetWallet(Guid walletId);
}