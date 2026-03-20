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

    // TODO: same as in storage, what to do if null?
    public WalletDetailsDTO GetWallet(Guid walletId)
    {
        var wallet = _repository.GetWallet(walletId);
        var walletAmount = _repository.GetAmountForWallet(wallet.Id);
        return new WalletDetailsDTO(wallet.Id, wallet.Name, wallet.Currency, walletAmount, wallet.OwnerFirstName,  wallet.OwnerLastName);
    }

    public IEnumerable<TransactionListDTO> GetTransactions(Guid walletId)
    {
        foreach (var transaction in _repository.GetTransactions(walletId))
        {
            var walletCurrency = _repository.GetWallet(transaction.WalletId).Currency;
            yield return new TransactionListDTO(transaction.Id, transaction.Amount, walletCurrency, transaction.PaymentCategory);
        }
    }
}