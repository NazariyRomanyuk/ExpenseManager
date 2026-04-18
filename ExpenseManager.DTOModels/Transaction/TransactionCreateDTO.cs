using ExpenseManager.Common.Enums;

namespace ExpenseManager.DTOModels.Wallet;

public class TransactionCreateDTO
{
    public Guid WalletId { get; }
    public decimal Amount { get; }
    public PaymentCategory PaymentCategory { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public TransactionCreateDTO(Guid walletId, decimal amount, PaymentCategory paymentCategory, string description,
        DateTime date)
    {
        WalletId = walletId;
        Amount = amount;
        PaymentCategory = paymentCategory;
        Description = description;
        Date = date;
    }
}