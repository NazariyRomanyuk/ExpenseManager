using ExpenseManager.DBModels;

namespace ExpenseManager.UIModels.EditModels;

public class WalletUIEditModel
{
    // Only the name, which is settable in the DB model present (+ Id).
    private readonly WalletDBModel _dbModel;
    private string _name;

    public Guid Id => _dbModel.Id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    public WalletUIEditModel(WalletDBModel dbModel)
    {
        _dbModel = dbModel;
        _name = dbModel.Name;
    }
    
    public void SaveChangesToDbModel()
    {
        _dbModel.Name = _name;
    }
}