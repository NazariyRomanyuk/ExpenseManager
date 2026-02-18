using ExpenseManager.Common;
using ExpenseManager.DBModels;
using ExpenseManager.Services;

namespace ExpenseManager.UIModels.EditModels;

public class WalletUiEditModel
{
    private WalletDbModel _dbModel;
    private string _name;

    public Guid Id => _dbModel.Id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    public WalletUiEditModel(WalletDbModel dbModel)
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
    }
    
    public void SaveChangesToDbModel()
    {
        if (string.IsNullOrWhiteSpace(_name)) throw new ArgumentException("Name cannot be null or empty.", nameof(_name));
        _dbModel.Name = _name;
    }
}