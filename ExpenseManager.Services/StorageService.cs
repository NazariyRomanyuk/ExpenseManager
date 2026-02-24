using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public class StorageService : IStorageService
{
    // Collections instantiated to suppress IntelliSense warnings.
    private List<WalletDbModel> _wallets = new();
    private List<TransactionDbModel> _transactions = new();
    // Loaded flag added to track data instead of comparing with null.
    private bool _loaded;

    private void LoadData()
    {
        if (_loaded) return;
        _wallets = DummyStorage.Wallets.ToList();
        _transactions = DummyStorage.Transactions.ToList();
        _loaded = true;
    }

    // IEnumerable to provide an interface which discourages modifications to the collection.
    // It is a copy however, and the elements of the collection are directly editable anyway due to being reference
    // types (which is ignored for the purposes of this lab), but it is good to give the user of the class a rough idea
    // of the intention.
    public IEnumerable<TransactionDbModel> GetTransactions(Guid walletId)
    {
        LoadData();
        return _transactions.Where(t => t.WalletId == walletId);
    }

    public IEnumerable<WalletDbModel> GetAllWallets()
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