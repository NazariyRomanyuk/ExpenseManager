using System.Transactions;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public class StorageService
{
    private List<WalletDbModel> _wallets = new();
    private List<TransactionDbModel> _transactions = new();
    private bool _loaded;

    private void LoadData()
    {
        if (_loaded) return;
        _wallets = DummyStorage.Wallets.ToList();
        _transactions = DummyStorage.Transactions.ToList();
        _loaded = true;
    }

    public IEnumerable<TransactionDbModel> GetTransactions(Guid walletId)
    {
        LoadData();
        return _transactions.Where(t => t.WalletId == walletId);
    }

    public IEnumerable<WalletDbModel> GetWallets()
    {
        LoadData();
        return _wallets.ToList();
    }

    public TransactionDbModel? GetTransaction(Guid transactionId)
    {
        LoadData();
        return _transactions.FirstOrDefault(w => w.Id == transactionId);
    }

    public WalletDbModel? GetWallet(Guid walletId)
    {
        LoadData();
        return _wallets.FirstOrDefault(w => w.Id == walletId);
    }
    
    
}