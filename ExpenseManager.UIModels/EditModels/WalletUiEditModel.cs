using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.EditModels;

public class WalletUiEditModel
{
    // Only the name, which is settable in the DB model present (+ Id).
    private readonly WalletDbModel _dbModel;
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
        _dbModel.Name = _name;
    }
}