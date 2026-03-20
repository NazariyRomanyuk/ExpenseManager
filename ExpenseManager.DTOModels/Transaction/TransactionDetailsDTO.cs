using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Transaction;

public class TransactionDetailsDTO
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public Currency Currency { get; }
    public PaymentCategory PaymentCategory { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public string WalletName { get; }

    public TransactionDetailsDTO(Guid id, decimal amount, Currency currency, PaymentCategory paymentCategory, string description, 
        DateTime date, string walletName)
    {
        Id = id;
        Amount = amount;
        Currency = currency;
        PaymentCategory = paymentCategory;
        Description = description;
        Date = date;
        WalletName = walletName;
    }
}