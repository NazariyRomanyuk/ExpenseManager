using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExpenseManager.DTOModels;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public class WalletDetailsViewModel : IQueryAttributable, INotifyPropertyChanged
{
    private readonly IService _service;
    private WalletDto _currentWallet;
    public WalletDto CurrentWallet {
        get => _currentWallet;
        private set {
            _currentWallet = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public WalletDetailsViewModel(IService service)
    {
        _service = service;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var walletId = (Guid)query["WalletId"];
        CurrentWallet = _service.GetWallet(walletId);
    }
    

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}