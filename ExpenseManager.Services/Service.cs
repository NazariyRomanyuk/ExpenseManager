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
    public IEnumerable<WalletListDTO> GetAllWallets()
    {
        foreach (var wallet in _repository.GetAllWallets())
        {
            var walletAmount = _repository.GetAmountForWallet(wallet.Id);
            yield return new WalletListDTO(wallet.Id, wallet.Name, wallet.Currency, walletAmount);
        }
    }
    
    public WalletDetailsDTO GetWallet(Guid walletId)
    {
        var wallet = _repository.GetWallet(walletId) ?? throw new EntityNotFoundException("Wallet", walletId);
        var walletAmount = _repository.GetAmountForWallet(wallet.Id);
        return new WalletDetailsDTO(wallet.Id, wallet.Name, wallet.Currency, walletAmount, wallet.OwnerFirstName,  wallet.OwnerLastName);
    }

    public IEnumerable<TransactionListDTO> GetTransactions(Guid walletId)
    {
        foreach (var transaction in _repository.GetTransactions(walletId))
        {
            var wallet = _repository.GetWallet(transaction.WalletId) ??  throw new EntityNotFoundException("Wallet", transaction.WalletId);
            yield return new TransactionListDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory);
        }
    }

    public TransactionDetailsDTO GetTransaction(Guid transactionId)
    {
        var transaction = _repository.GetTransaction(transactionId) ?? throw new EntityNotFoundException("Transaction", transactionId);
        var wallet = _repository.GetWallet(transaction.WalletId) ?? throw new EntityNotFoundException("Wallet", transaction.WalletId);
        return new TransactionDetailsDTO(transaction.Id, transaction.Amount, wallet.Currency, transaction.PaymentCategory, transaction.Description, 
            transaction.Date, wallet.Name);
    }
}