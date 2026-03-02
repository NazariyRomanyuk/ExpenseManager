using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Common.Enums;

public enum Currency
{
    [Display(Name = "UAH")]
    Uah,
    [Display(Name = "USD")]
    Usd,
    [Display(Name = "EUR")]
    Eur,
    [Display(Name = "GBP")]
    Gbp,
    [Display(Name = "CHF")]
    Chf,
    [Display(Name = "JPY")]
    Jpy
}