using System.Transactions;
using ExpenseManager.DBModels;

namespace ExpenseManager.Services;

public class StorageService
{
    private List<WalletDBModel> _wallets;
    private List<TransactionDBModel> _transactions;
}