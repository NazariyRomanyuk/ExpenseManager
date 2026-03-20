using ExpenseManager.Common;
using ExpenseManager.Common.Enums;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.EditModels;

public class TransactionUIEditModel
{
    // Only fields that are settable in the DB model present (+ Id).
    private readonly TransactionDBModel _dbModel;
    private PaymentCategory _paymentCategory;
    private decimal _amount;
    private string _description;
    
    public Guid Id => _dbModel.Id;
    
    public PaymentCategory PaymentCategory
    {
        get => _paymentCategory;
        set => _paymentCategory = value;
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
    
    public TransactionUIEditModel(TransactionDBModel dbModel)
    {
        _dbModel = dbModel;
        _paymentCategory = dbModel.PaymentCategory;
        _description = dbModel.Description;
        _amount = dbModel.Amount;
    }

    public void SaveChangesToDbModel()
    {
        _dbModel.PaymentCategory =  _paymentCategory;
        _dbModel.Description = _description;
        _dbModel.Amount = _amount;
    }
}