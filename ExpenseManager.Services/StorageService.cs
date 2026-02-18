using System.Transactions;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public class StorageService
{
    private List<WalletDBModel> _wallets = new();
    private List<TransactionDBModel> _transactions = new();
    private bool _loaded;

    private void LoadData()
    {
        if (_loaded) return;
        _wallets = DummyStorage.Wallets.ToList();
        _transactions = DummyStorage.Transactions.ToList();
        _loaded = true;
    }

    public IEnumerable<TransactionDBModel> GetTransactions(Guid walletId)
    {
        LoadData();
        return _transactions.Where(t => t.WalletId == walletId);
    }

    public IEnumerable<WalletDBModel> GetWallets()
    {
        LoadData();
        return _wallets.ToList();
    }

    public TransactionDBModel? GetTransaction(Guid transactionId)
    {
        LoadData();
        return _transactions.FirstOrDefault(w => w.Id == transactionId);
    }

    public WalletDBModel? GetWallet(Guid walletId)
    {
        LoadData();
        return _wallets.FirstOrDefault(w => w.Id == walletId);
    }
    
    
}