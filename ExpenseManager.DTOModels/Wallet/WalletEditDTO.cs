using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Wallet;

public class WalletEditDTO
{
    public Guid Id { get; }
    public string Name { get; }
    public Currency Currency { get; }
    public string OwnerFirstName { get; }
    public string OwnerLastName { get; }

    public WalletEditDTO(Guid id, string name, Currency currency, string ownerFirstName, string ownerLastName)
    {
        Id = id;
        Name = name;
        Currency = currency;
        OwnerFirstName = ownerFirstName;
        OwnerLastName = ownerLastName;
    }
}