using ExpenseManager.Common;

namespace ExpenseManager.DBModels;

public class TransactionDbModel
{
    public Guid Id { get; }
    public Guid WalletId { get; }
    public decimal Amount { get; }
    public PaymentCategory PaymentCategory { get; set; }
    public string Description { get; set; }
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