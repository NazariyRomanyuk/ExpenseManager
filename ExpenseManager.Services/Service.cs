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
    public IEnumerable<WalletListDto> GetAllWallets()
    {
        foreach (var wallet in _repository.GetAllWallets())
        {
            var walletAmount = _repository.GetAmountForWallet(wallet.Id);
            yield return new WalletListDto(wallet.Id, wallet.Name, wallet.Currency, walletAmount);
        }
    }
}