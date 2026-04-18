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

public partial class WalletDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IService _service;
    private Guid _walletId;

    [ObservableProperty] public partial WalletDetailsDTO CurrentWallet { get; private set; } = null!;

    [ObservableProperty] public partial ObservableCollection<TransactionListDTO> Transactions { get; set; } = null!;

    public WalletDetailsViewModel(IService service)
    {
        _service = service;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _walletId = (Guid)query["WalletId"];
    }

    [RelayCommand]
    public async Task Refresh()
    {
        IsBusy = true;
        try
        {
            CurrentWallet = await _service.GetWalletAsync(_walletId);
            Transactions = new ObservableCollection<TransactionListDTO>();
            await foreach (var item in _service.GetTransactionsAsync(_walletId))
                Transactions.Add(item);
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", e.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task LoadTransaction(Guid transactionId)
    {
        IsBusy = true;
        try
        {
            await Shell.Current.GoToAsync($"{nameof(TransactionDetailsPage)}",
                new Dictionary<string, object> { { "transactionId", transactionId } });
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to load transaction details: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task AddTransaction()
    {
        IsBusy = true;
        try
        {
            await Shell.Current.GoToAsync($"{nameof(TransactionCreatePage)}", new Dictionary<string, object> { { nameof(TransactionCreateDTO.WalletId), _walletId } });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to transaction create page: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task DeleteTransaction(TransactionListDTO transaction)
    {
        IsBusy = true;
        try
        {
            if (await Shell.Current.DisplayAlertAsync("Confirm", "Are you sure you want to delete this transaction?",
                    "Yes", "No"))
            {
                await _service.DeleteTransactionAsync(transaction.Id);
                Transactions.Remove(transaction);
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to delete transaction: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task EditTransaction(TransactionListDTO transaction)
    {
        IsBusy = true;
        try
        {
            var details = await _service.GetTransactionAsync(transaction.Id);
            await Shell.Current.GoToAsync($"{nameof(TransactionEditPage)}", 
                new Dictionary<string, object> { { "Transaction", details }, { "WalletId", _walletId } });
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to transaction edit page: {e.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
}