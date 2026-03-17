using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels;

public class WalletListDto
{
    public Guid Id { get; }
    public string Name { get; }
    public Currency Currency { get; }
    public decimal Amount { get; set; }
    public WalletListDto(Guid id, string name, Currency currency, decimal amount)
    {
        Id = id;
        Name = name;
        Currency = currency;
        Amount = amount;
    }
}