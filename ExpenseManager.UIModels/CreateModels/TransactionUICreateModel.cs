using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.CreateModels;

public class TransactionUICreateModel
{
    private readonly Guid _walletId;
    private decimal _amount;
    private PaymentCategory _paymentCategory;
    // Initialized to suppress IntelliSense warnings about potential null reference types.
    private string _description = string.Empty;
    private DateTime _date;

    // No Id needed - not created yet.
    
    // Wallet not directly settable - set through constructor.
    public Guid WalletId => _walletId;
    
    // All properties present with setters to instantiate the object.
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

    public TransactionUICreateModel(Guid walletId)
    {
        _walletId = walletId;
    }

    public TransactionDBModel CreateDbModel ()
    { 
        return new TransactionDBModel(_walletId,  _amount, _paymentCategory, _description, _date);
    }
    
}