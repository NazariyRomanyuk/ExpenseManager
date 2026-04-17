using ExpenseManager.Common.Exceptions;
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
            yield return new TransactionListDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory);
        }
    }

    public async Task<TransactionDetailsDTO> GetTransactionAsync(Guid transactionId)
    {
        var transaction = await _repository.GetTransactionAsync(transactionId) ?? throw new EntityNotFoundException("Transaction", transactionId);
        var wallet = await _repository.GetWalletAsync(transaction.WalletId) ?? throw new EntityNotFoundException("Wallet", transaction.WalletId);
        return new TransactionDetailsDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory, transaction.Description, 
            transaction.Date, wallet.Name);
    }
}