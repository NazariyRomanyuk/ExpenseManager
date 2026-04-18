using ExpenseManager.Common.Enums;
using ExpenseManager.DTOModels.Transaction;
using ExpenseManager.DTOModels.Wallet;

namespace ExpenseManager.Services;

public static class Validators
{
    public record struct ValidationError(string ErrorMessage, string PropertyName);

    public static List<ValidationError> Validate(this TransactionCreateDTO potentialTransaction)
    {
        var errors = new List<ValidationError>();
        if (potentialTransaction.WalletId == Guid.Empty)
            errors.Add(new ValidationError("Transaction must be assigned to a wallet.", nameof(TransactionCreateDTO.WalletId)));
        errors.AddRange(ValidateTransaction(potentialTransaction.Amount, potentialTransaction.PaymentCategory, 
            potentialTransaction.Description, potentialTransaction.Date));
        return errors;
    }

    public static List<ValidationError> ValidateTransaction(decimal amount, PaymentCategory? category,
        string description, DateTime date)
    {
        var errors = new List<ValidationError>();
        if (amount == 0)
            errors.Add(new ValidationError("Amount cannot be 0.", nameof(TransactionCreateDTO.Amount)));
        if (category is null)
            errors.Add(new ValidationError("Payment category is required.", nameof(TransactionCreateDTO.PaymentCategory)));
        errors.AddRange(ValidateDescription(description, nameof(TransactionCreateDTO.Description), "Description"));
        errors.AddRange(ValidateDate(date, "DateTime", "Date"));
        return errors;
    }
    
    public static List<ValidationError> ValidateDescription(string description, string propertyName, string displayName)
    {
        var errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(description))
        {
            errors.Add(new ValidationError($"{displayName} is required.", propertyName));
            return errors;
        }
        switch (description.Length)
        {
            case < 2:
                errors.Add(new ValidationError($"{displayName} must be at least 2 characters long.", propertyName));
                break;
            case > 100:
                errors.Add(new ValidationError($"{displayName} must be at less than or equal to 100 characters long.", propertyName));
                break;
        }
        return errors;
    }
    
    public static List<ValidationError> ValidateDate(DateTime? date, string propertyName, string displayName)
    {
        var errors = new List<ValidationError>();
        if (date is null) 
            errors.Add(new ValidationError($"{displayName} is required.", propertyName));
        if (date > DateTime.Now)
            errors.Add(new ValidationError($"{displayName} cannot be in the future.", propertyName));
        return errors;
    }
    
    public static List<ValidationError> Validate(this WalletCreateDTO potentialWallet)
    {
        var errors = new List<ValidationError>();
        errors.AddRange(ValidateWallet(potentialWallet.Name, potentialWallet.Currency, potentialWallet.OwnerFirstName,
            potentialWallet.OwnerLastName));
         return errors;
    }
    
    public static List<ValidationError> ValidateWallet(string name, Currency? currency, string ownerFirstName, string ownerLastName)
    {
        var errors = new List<ValidationError>();
        if (currency is null)
            errors.Add(new ValidationError("Currency is required.", nameof(WalletCreateDTO.Currency)));
        errors.AddRange(ValidateWalletName(name, nameof(WalletCreateDTO.Name), "Wallet Name"));
        errors.AddRange(ValidatePersonName(ownerFirstName, nameof(WalletCreateDTO.OwnerFirstName), "Owner First Name"));
        errors.AddRange(ValidatePersonName(ownerLastName, nameof(WalletCreateDTO.OwnerLastName), "Owner Last Name"));
        return errors;
    }
    
    public static List<ValidationError> ValidatePersonName(string name, string propertyName, string displayName)
    {
        var errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(new ValidationError($"{displayName} is required.", propertyName));
            return errors;
        }
        switch (name.Length)
        {
            case < 2:
                errors.Add(new ValidationError($"{displayName} must be at least 2 characters long.", propertyName));
                break;
            case > 50:
                errors.Add(new ValidationError($"{displayName} must be at less than or equal to 50 characters long.", propertyName));
                break;
        }
        if (!name.All(char.IsLetter))
            errors.Add(new ValidationError($"{displayName} must consist of only letters.", propertyName));
        return errors;
    }
    
    public static List<ValidationError> ValidateWalletName(string name, string propertyName, string displayName)
    {
        var errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(new ValidationError($"{displayName} is required.", propertyName));
            return errors;
        }
        switch (name.Length)
        {
            case < 2:
                errors.Add(new ValidationError($"{displayName} must be at least 2 characters long.", propertyName));
                break;
            case > 50:
                errors.Add(new ValidationError($"{displayName} must be at less than or equal to 50 characters long.", propertyName));
                break;
        }
        if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || !name.Any(char.IsLetter))
            errors.Add(new ValidationError($"{displayName} must consist of only letters or spaces.", propertyName));
        return errors;
    }
    
    
    
    
}