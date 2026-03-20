using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Wallet;

public class WalletDetailsDto
{
    public Guid Id { get; }
    public string Name { get; }
    public Currency Currency { get; }
    public decimal Amount { get; set; }
    public string OwnerFirstName { get; }
    public string OwnerLastName { get; }
    public WalletDetailsDto(Guid id, string name, Currency currency, decimal amount, string ownerFirstName, string ownerLastName)
    {
        Id = id;
        Name = name;
        Currency = currency;
        Amount = amount;
        OwnerFirstName = ownerFirstName;
        OwnerLastName = ownerLastName;
    }
}