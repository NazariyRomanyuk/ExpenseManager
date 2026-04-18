using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Transaction;

public class TransactionListDTO
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public Currency Currency { get; }
    public PaymentCategory PaymentCategory { get; }
    public string Description { get; }

    public TransactionListDTO(Guid id, decimal amount, Currency currency, PaymentCategory paymentCategory, string description)
    {
        Id = id;
        Amount = amount;
        Currency = currency;
        PaymentCategory = paymentCategory;
        Description = description;
    }
    
}