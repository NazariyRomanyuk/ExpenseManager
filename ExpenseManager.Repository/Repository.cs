using ExpenseManager.DBModels;
using ExpenseManager.Storage;

namespace LecturerManager.Repository;

public class Repository : IRepository
{
    private readonly IStorageContext _storageContext;
    public Repository(IStorageContext storageContext)
    {
        _storageContext = storageContext;
    }
    public IEnumerable<WalletDBModel> GetAllWallets()
    {
        return _storageContext.GetAllWallets();
    }

    public IEnumerable<TransactionDBModel> GetTransactions(Guid walletId)
    {
        return _storageContext.GetTransactions(walletId);
    }

    public WalletDBModel? GetWallet(Guid walletId)
    {
        return _storageContext.GetWallet(walletId);
    }

    public TransactionDBModel? GetTransaction(Guid transactionId)
    {
        return _storageContext.GetTransaction(transactionId);
    }

    public decimal GetAmountForWallet(Guid walletId)
    {
        return _storageContext.GetAmountForWallet(walletId);
    }
}