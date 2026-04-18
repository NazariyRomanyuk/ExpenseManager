using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Wallet;

public class WalletCreateDTO
{
    public string Name { get; }
    public Currency Currency { get; }
    public string OwnerFirstName { get; }
    public string OwnerLastName { get; }

    public WalletCreateDTO(string name, Currency currency, string ownerFirstName, string ownerLastName)
    {
        Name = name;
        Currency = currency;
        OwnerFirstName = ownerFirstName;
        OwnerLastName = ownerLastName;
    }
}