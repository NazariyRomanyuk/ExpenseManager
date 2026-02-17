using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.EditModels;

public class TransactionUIEditModel
{
    private readonly TransactionDBModel _dbModel;
    private PaymentCategory _paymentCategory;
    private string _description;
    public Guid Id => _dbModel.Id;
    
    public PaymentCategory PaymentCategory
    {
        get => _dbModel.PaymentCategory;
        set => _paymentCategory = value;
    }
    
    public string Description
    {
        get => _dbModel.Description;
        set => _description = value;
    }
    
    public TransactionUIEditModel(TransactionDBModel dbModel)
    {
        _dbModel = dbModel;
        _paymentCategory = dbModel.PaymentCategory;
        _description = dbModel.Description;
    }

    public void SaveChangesToDBModel()
    {
        if (string.IsNullOrWhiteSpace(_description)) throw new ArgumentNullException(nameof(_description), "Description cannot be null or empty.");
        _dbModel.PaymentCategory =  _paymentCategory;
        _dbModel.Description = _description;
    }
}