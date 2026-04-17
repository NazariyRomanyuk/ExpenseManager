using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseManager.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    public partial bool IsBusy { get; set; } = false;
    public bool IsNotBusy => !IsBusy;
}