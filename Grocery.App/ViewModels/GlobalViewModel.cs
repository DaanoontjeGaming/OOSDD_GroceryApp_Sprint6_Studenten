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

        [ObservableProperty]
        private bool cardOpgezegd = false;

        public string BonusStatus => HasBonusCard ? "Bonus: Ja" : "Bonus: Nee";

        public string OpgezegdStatus => CardOpgezegd ? "Opgezegd: Ja" : "Opgezegd: Nee";

        partial void OnHasBonusCardChanged(bool value)
        {
            OnPropertyChanged(nameof(BonusStatus));
            OnPropertyChanged(nameof(OpgezegdStatus));
        }

        partial void OnCardOpgezegdChanged(bool value)
        {
            OnPropertyChanged(nameof(OpgezegdStatus));
        }
    }
}
