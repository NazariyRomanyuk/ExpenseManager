using ExpenseManager.Common;
using ExpenseManager.Common.Enums;

namespace ExpenseManager.DBModels;

public class TransactionDbModel
{
    // Id is only set once during creation.
    public Guid Id { get; }
    // Transaction can only belong to one wallet after its instantiation.
    public Guid WalletId { get; }
    // Amount modifiable due to likely possible typos. Decimal for accurate monetary calculations.
    public decimal Amount { get; set; }
    // Category modifiable due to likely possible mishaps/changes in category logic.
    public PaymentCategory PaymentCategory { get; set; }
    // Description modifiable due to likely possible typos/mistakes.
    public string Description { get; set; }
    // Date not modifiable due to being assigned at transaction creation time.
    public DateTime Date { get; }

    public TransactionDbModel(Guid walletId, decimal amount, PaymentCategory paymentCategory, 
        string description, DateTime date)
    {
        Id = Guid.NewGuid();
        WalletId = walletId;
        Amount = amount;
        PaymentCategory = paymentCategory;
        Description = description;
        Date = date;
    }
    
}