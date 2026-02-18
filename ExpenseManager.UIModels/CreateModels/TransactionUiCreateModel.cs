using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.CreateModels;

public class TransactionUiCreateModel
{
    private readonly Guid _walletId;
    private decimal _amount;
    private PaymentCategory _paymentCategory;
    private string _description = string.Empty;
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
    public decimal Amount 
    {
        get => _amount;
        set => _amount = value;
    }
    public DateTime Date
    {
        get => _date;
        set => _date = value;
    }

    public TransactionUiCreateModel(Guid walletId)
    {
        _walletId = walletId;
    }

    public TransactionDbModel CreateDbModel ()
    { 
        return new TransactionDbModel(_walletId,  _amount, _paymentCategory, _description, _date);
    }
    
}