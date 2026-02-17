using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.ViewModels;

public class TransactionUIViewModel
{
    private TransactionDBModel _dbModel;

    public Guid Id => _dbModel.Id;
    public Guid WalletId => _dbModel.WalletId;
    public decimal Amount =>  _dbModel.Amount;
    public PaymentCategory PaymentCategory =>  _dbModel.PaymentCategory;
    public string Description =>  _dbModel.Description;
    public DateTime Date =>  _dbModel.Date;
    public bool isExpense => _dbModel.Amount < 0;

    public TransactionUIViewModel(TransactionDBModel dbModel)
    {
        _dbModel = dbModel;
    }
    public override string ToString()
    {
        return $"Transaction for {Amount} in {PaymentCategory}: {Description}";
    }
    
}