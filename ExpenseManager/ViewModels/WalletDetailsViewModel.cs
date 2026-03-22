using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseManager.Common.Exceptions;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;
using ExpenseManager.Pages;
using ExpenseManager.Services;

namespace ExpenseManager.ViewModels;

public partial class WalletDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IService _service;
    
    [ObservableProperty]
    public partial WalletDetailsDTO CurrentWallet {get; private set;}

    [ObservableProperty]
    public partial ObservableCollection<TransactionListDTO> Transactions { get; set; }

    public WalletDetailsViewModel(IService service)
    {
        _service = service;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var walletId = (Guid)query["WalletId"];
        try
        {
            CurrentWallet = _service.GetWallet(walletId);
        }
        catch (EntityNotFoundException e)
        {
            Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
            return;
        }
        Transactions = new ObservableCollection<TransactionListDTO>(_service.GetTransactions(walletId));
        OnPropertyChanged(nameof(Transactions));
    }

    [RelayCommand]
    private void LoadTransaction(Guid transactionId)
    {
        Shell.Current.GoToAsync($"{nameof(TransactionDetailsPage)}",
            new Dictionary<string, object>{{ "transactionId", transactionId }});
    }
    
}