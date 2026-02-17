using System.Transactions;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public class StorageService
{
    private List<WalletDBModel> _wallets;
    private List<TransactionDBModel> _transactions;

    private void LoadData()
    {
        if (_wallets != null && _transactions != null) return;
        _wallets = DummyStorage.Wallets.ToList();
        _transactions = DummyStorage.Transactions.ToList();
    }

    public IEnumerable<TransactionDBModel> GetTransactions(Guid walletId)
    {
        LoadData();
        return _transactions.Where(w => w.Id == walletId);
    }

    public IEnumerable<WalletDBModel> GetWallets()
    {
        LoadData();
        return _wallets.ToList();
    }
}