using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Common.Enums;

public enum PaymentCategory
{
    [Display(Name = "Shopping")]
    Shopping,
    [Display(Name = "Food and Beverage")]
    FoodAndBeverage,
    [Display(Name = "Automobile Services")]
    AutomobileServices,
    [Display(Name = "Entertainment")]
    Entertainment,
    [Display(Name = "Online Services")]
    OnlineServices,
    [Display(Name = "Taxi")]
    Taxi,
    [Display(Name = "Crediting")]
    Crediting
}