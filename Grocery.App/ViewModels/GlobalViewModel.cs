using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class GlobalViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Client? client;

        [ObservableProperty]
        private bool hasBonusCard = false;

        public string BonusStatus => HasBonusCard ? "Bonus: Ja" : "Bonus: Nee";

        partial void OnHasBonusCardChanged(bool value)
        {
            OnPropertyChanged(nameof(BonusStatus));
        }
    }
}
