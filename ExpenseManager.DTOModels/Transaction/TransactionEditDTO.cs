using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Transaction;

public class TransactionEditDTO
{
    public Guid Id { get; }
    public Guid WalletId { get; }
    public decimal Amount { get; }
    public PaymentCategory PaymentCategory { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public TransactionEditDTO(Guid id, Guid walletId, decimal amount, PaymentCategory paymentCategory, string description,
        DateTime date)
    {
        Id = id;
        WalletId = walletId;
        Amount = amount;
        PaymentCategory = paymentCategory;
        Description = description;
        Date = date;
    }
}