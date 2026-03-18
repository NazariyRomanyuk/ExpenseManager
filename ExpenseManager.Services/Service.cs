using ExpenseManager.DTOModels;
using LecturerManager.Repository;

namespace ExpenseManager.Services;

public class Service : IService
{
    private readonly IRepository _repository;
    public Service(IRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<WalletDto> GetAllWallets()
    {
        foreach (var wallet in _repository.GetAllWallets())
        {
            var walletAmount = _repository.GetAmountForWallet(wallet.Id);
            yield return new WalletDto(wallet.Id, wallet.Name, wallet.Currency, walletAmount);
        }
    }

    // TODO: same as in storage, what to do if null?
    public WalletDto GetWallet(Guid walletId)
    {
        var wallet = _repository.GetWallet(walletId);
        var walletAmount = _repository.GetAmountForWallet(wallet.Id);
        return new WalletDto(wallet.Id, wallet.Name, wallet.Currency, walletAmount);
    }
}