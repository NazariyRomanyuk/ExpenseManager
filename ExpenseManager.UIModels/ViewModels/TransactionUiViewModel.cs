using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.ViewModels;

public class TransactionUiViewModel
{
    // Properties only have getters - view model has no access to setting.
    private readonly TransactionDbModel _dbModel;

    public Guid Id => _dbModel.Id;
    public Guid WalletId => _dbModel.WalletId;
    public decimal Amount => _dbModel.Amount;
    public PaymentCategory PaymentCategory => _dbModel.PaymentCategory;
    public string Description => _dbModel.Description;
    public DateTime Date =>  _dbModel.Date;
    public bool IsExpense => _dbModel.Amount < 0;
    // The currency, associated with the wallet, is good to have for view - obtained from above through constructor.
    // Not really achievable otherwise without intertwining it with StorageService - which is bad for a simple view model.
    public Currency Currency { get; }
    
    public TransactionUiViewModel(TransactionDbModel dbModel, Currency currency)
    {
        _dbModel = dbModel;
        Currency = currency;
    }
    public override string ToString()
    {
        return $"Transaction for {Amount} {Currency} in {PaymentCategory} on {Date}. Is Expense = {IsExpense} \n \"{Description}\"\n";
    }
    
}