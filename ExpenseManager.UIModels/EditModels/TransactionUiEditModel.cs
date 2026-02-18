using ExpenseManager.Common;
using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.EditModels;

public class TransactionUiEditModel
{
    private readonly TransactionDbModel _dbModel;
    private PaymentCategory _paymentCategory;
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
    
    public TransactionUiEditModel(TransactionDbModel dbModel)
    {
        _dbModel = dbModel;
        _paymentCategory = dbModel.PaymentCategory;
        _description = dbModel.Description;
    }

    public void SaveChangesToDbModel()
    {
        if (string.IsNullOrWhiteSpace(_description)) throw new ArgumentNullException(nameof(_description), "Description cannot be null or empty.");
        _dbModel.PaymentCategory =  _paymentCategory;
        _dbModel.Description = _description;
    }
}