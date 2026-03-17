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
    public IEnumerable<WalletDbModel> GetAllWallets()
    {
        return _storageContext.GetAllWallets();
    }

    public IEnumerable<TransactionDbModel> GetTransactions(Guid walletId)
    {
        return _storageContext.GetTransactions(walletId);
    }

    public WalletDbModel GetWallet(Guid walletId)
    {
        return _storageContext.GetWallet(walletId);
    }

    public TransactionDbModel GetTransaction(Guid transactionId)
    {
        return _storageContext.GetTransaction(transactionId);
    }

    public decimal GetAmountForWallet(Guid walletId)
    {
        return _storageContext.GetAmountForWallet(walletId);
    }
}