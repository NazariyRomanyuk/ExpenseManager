using System.ComponentModel.DataAnnotations;
using ExpenseManager.Common.Exceptions;
using ExpenseManager.DBModels;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;
using LecturerManager.Repository;

namespace ExpenseManager.Services;

public class Service : IService
{
    private readonly IRepository _repository;
    public Service(IRepository repository)
    {
        _repository = repository;
    }
    public async IAsyncEnumerable<WalletListDTO> GetAllWalletsAsync()
    {
        await foreach (var wallet in _repository.GetAllWalletsAsync())
        {
            var walletAmount = await _repository.GetAmountForWalletAsync(wallet.Id);
            yield return new WalletListDTO(wallet.Id, wallet.Name, wallet.Currency, walletAmount);
        }
    }
    
    public async Task<WalletDetailsDTO> GetWalletAsync(Guid walletId)
    {
        var wallet = await _repository.GetWalletAsync(walletId) ?? throw new EntityNotFoundException("Wallet", walletId);
        var walletAmount = await _repository.GetAmountForWalletAsync(wallet.Id);
        return new WalletDetailsDTO(wallet.Id, wallet.Name, wallet.Currency, walletAmount, wallet.OwnerFirstName,  wallet.OwnerLastName);
    }

    public async IAsyncEnumerable<TransactionListDTO> GetTransactionsAsync(Guid walletId)
    {
        await foreach (var transaction in _repository.GetTransactionsAsync(walletId))
        {
            var wallet = await _repository.GetWalletAsync(transaction.WalletId) ??  throw new EntityNotFoundException("Wallet", transaction.WalletId);
            yield return new TransactionListDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory, transaction.Description);
        }
    }

    public async Task<TransactionDetailsDTO> GetTransactionAsync(Guid transactionId)
    {
        var transaction = await _repository.GetTransactionAsync(transactionId) ?? throw new EntityNotFoundException("Transaction", transactionId);
        var wallet = await _repository.GetWalletAsync(transaction.WalletId) ?? throw new EntityNotFoundException("Wallet", transaction.WalletId);
        return new TransactionDetailsDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory, transaction.Description, 
            transaction.Date, wallet.Name);
    }

    public async Task CreateWalletAsync(WalletCreateDTO wallet)
    {
        var walletDbModel = new WalletDBModel(wallet.Name, wallet.Currency, wallet.OwnerFirstName, wallet.OwnerLastName);
        await _repository.AddWalletAsync(walletDbModel);
    }
    
    public async Task UpdateWalletAsync(WalletEditDTO wallet)
    {
        var walletDbModel = new WalletDBModel(wallet.Id, wallet.Name, wallet.Currency, wallet.OwnerFirstName, wallet.OwnerLastName);
        await _repository.UpdateWalletAsync(walletDbModel);
    }

    public async Task DeleteWalletAsync(Guid walletId)
    {
        var transactions = new List<TransactionDBModel>();
        await foreach (var transaction in _repository.GetTransactionsAsync(walletId))
            transactions.Add(transaction);
    
        foreach (var transaction in transactions)
            await _repository.DeleteTransactionAsync(transaction.Id);
    
        await _repository.DeleteWalletAsync(walletId);
    }

    public async Task CreateTransactionAsync(TransactionCreateDTO transaction)
    {
        var transactionDbModel = new TransactionDBModel(transaction.WalletId, transaction.Amount, transaction.PaymentCategory, 
            transaction.Description, transaction.Date);
        await _repository.AddTransactionAsync(transactionDbModel);
    }

    public async Task UpdateTransactionAsync(TransactionEditDTO transaction)
    {
        var transactionDbModel = new TransactionDBModel(transaction.Id, transaction.WalletId, transaction.Amount, transaction.PaymentCategory, 
            transaction.Description, transaction.Date);
        await _repository.UpdateTransactionAsync(transactionDbModel);
    }

    public Task DeleteTransactionAsync(Guid transactionId)
    {
        return _repository.DeleteTransactionAsync(transactionId);
    }
}