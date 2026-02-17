using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.CreateModels;

public class TransactionUICreateModel
{
    private Guid _walletId;
    private decimal _amount;
    private PaymentCategory _paymentCategory;
    private string _description;
    private DateTime _date;

    public Guid WalletId => _walletId;
    
    public PaymentCategory PaymentCategory
    {
        get => _paymentCategory;
        set  => _paymentCategory = value;
    }
    
    public string Description
    {
        get => _description;
        set => _description = value;
    }
    public decimal Amount => _amount;
    public DateTime Date => _date;

    public TransactionUICreateModel(Guid walletId)
    {
        _walletId = walletId;
    }

    public TransactionDBModel CreateDBModel (TransactionDBModel dbModel)
    { 
        return new TransactionDBModel(_walletId,  _amount, _paymentCategory, _description, _date);
    }
    
}