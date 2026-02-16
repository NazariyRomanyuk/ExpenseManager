using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels;

public class TransactionUIModel
{
    private TransactionDBModel _dbModel;
    private Guid _walletId;
    private decimal _amount;
    private PaymentCategory _paymentCategory;
    private string _description;
    private DateTime _date;

    public Guid? Id
    {
        get => _dbModel?.Id;
    }
    
    public Guid WalletId
    {
        get => _walletId;
    }
    
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (_dbModel != null) return;
            _amount = value;
        }
    }
    
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
    
    public DateTime Date 
    {
        get => _date;
    }

    public bool isExpense
    {
        get => _amount < 0;
    }

    public TransactionUIModel(Guid walletId)
    {
        _walletId = walletId;
    }

    public TransactionUIModel(TransactionDBModel dbModel)
    {
        _dbModel = dbModel;
        _walletId = dbModel.WalletId;
        _amount = dbModel.Amount;
        _paymentCategory = dbModel.PaymentCategory;
        _description = dbModel.Description;
        _date = dbModel.Date;
    }
    
}