using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Transaction;

public class TransactionListDto
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public Currency Currency { get; }
    public PaymentCategory PaymentCategory { get; }

    public TransactionListDto(Guid id, decimal amount, Currency currency, PaymentCategory paymentCategory)
    {
        Id = id;
        Amount = amount;
        Currency = currency;
        PaymentCategory = paymentCategory;
    }
    
}