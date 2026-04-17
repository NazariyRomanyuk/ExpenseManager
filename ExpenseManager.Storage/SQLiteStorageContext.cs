using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;
using Microsoft.VisualBasic;
using SQLite;

namespace ExpenseManager.Storage;

public class SQLiteStorageContext : IStorageContext
{
    private SQLiteAsyncConnection? _connection;
    private const string DatabaseName = "expense_manager.db3";
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ExpenseManager", DatabaseName);

    private async Task Init()
    {
        if (_connection is not null) return;
        bool fileExists = File.Exists(DatabasePath);
        if (!fileExists) await CreateDummyStorage(); 
        else _connection = new SQLiteAsyncConnection(DatabasePath);
    }

    private async Task CreateDummyStorage()
    {
        var directory = Path.GetDirectoryName(DatabasePath);
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        
        _connection = new SQLiteAsyncConnection(DatabasePath);
        var inMemoryStorage = new InMemoryStorageContext();
        await _connection.CreateTableAsync<WalletDBModel>();
        await _connection.CreateTableAsync<TransactionDBModel>();
        await foreach (var wallet in inMemoryStorage.GetAllWalletsAsync())
        {
            await _connection.InsertAsync(wallet);
            await foreach(var transaction in inMemoryStorage.GetTransactionsAsync(wallet.Id))
                await _connection.InsertAsync(transaction);
        }
    }

    public async IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId)
    {
        await Init();
        foreach (var transaction in await _connection!.Table<TransactionDBModel>().Where(x => x.WalletId == walletId).ToListAsync())
            yield return transaction;
    }

    public async IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync()
    {
        await Init();
        var all = await _connection!.Table<WalletDBModel>().ToListAsync();
        foreach  (var wallet in all)
            yield return wallet;
    }

    public async Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId)
    {
        await Init();
        return await _connection!.Table<TransactionDBModel>().Where(x => x.Id == transactionId).FirstOrDefaultAsync();
    }

    public async Task<WalletDBModel?> GetWalletAsync(Guid walletId)
    {
        await Init();
        return await _connection!.Table<WalletDBModel>().Where(x => x.Id == walletId).FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAmountForWalletAsync(Guid walletId)
    {
        await Init();
        var transactions = await _connection!.Table<TransactionDBModel>().Where(x => x.WalletId == walletId).ToListAsync();
        return transactions.Sum(transaction => transaction.Amount);
    }

    public async Task AddWalletAsync(WalletDBModel wallet)
    {
        await Init();
        await _connection!.InsertAsync(wallet);
    }

    public async Task DeleteWalletAsync(Guid walletId)
    {
        await Init();
        await _connection!.DeleteAsync(walletId);
    }

    public async Task UpdateWalletAsync(WalletDBModel wallet)
    {
        await Init();
        await _connection!.UpdateAsync(wallet);
    }

    public async Task AddTransactionAsync(TransactionDBModel transaction)
    {
        await Init();
        await _connection!.InsertAsync(transaction);
    }

    public async Task DeleteTransactionAsync(Guid transactionId)
    {
        await Init();
        await _connection!.DeleteAsync(transactionId);
    }

    public async Task UpdateTransactionAsync(TransactionDBModel transaction)
    {
        await Init();
        await _connection!.UpdateAsync(transaction);
    }
}