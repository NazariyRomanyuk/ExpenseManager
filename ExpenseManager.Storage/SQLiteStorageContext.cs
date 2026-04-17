using ExpenseManager.DBModels;
using SQLite;

namespace ExpenseManager.Storage;

public class SQLiteStorageContext : IStorageContext
{
    private SQLiteAsyncConnection? _connection;
    private const string DatabaseName = "expense_manager.db";
    private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DatabaseName);

    private async Task Init()
    {
        if (_connection != null) return;
        bool fileExists = File.Exists(DatabasePath);
        if (!fileExists)
            await CreateDummyStorage();
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
        //await foreach (var wallet in inMemoryStorage.GetAllWallets())
        
    }

    public IAsyncEnumerable<TransactionDBModel> GetTransactionsAsync(Guid walletId)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<WalletDBModel> GetAllWalletsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TransactionDBModel?> GetTransactionAsync(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<WalletDBModel?> GetWalletAsync(Guid walletId)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetAmountForWalletAsync(Guid walletId)
    {
        throw new NotImplementedException();
    }
}