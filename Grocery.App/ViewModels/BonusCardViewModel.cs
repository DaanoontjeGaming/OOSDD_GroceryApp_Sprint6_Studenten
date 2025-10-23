using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Grocery.App.ViewModels
{
    public partial class BonusCardViewModel : BaseViewModel
    {
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        decimal price = 149.99m;

        [ObservableProperty]
        string infoMessage = string.Empty;

        [ObservableProperty]
        bool hasBonusCard = false;

        public BonusCardViewModel(GlobalViewModel global)
        {
            Title = "Bonuskaart";
            _global = global;
        }

        public bool CanBuy => !HasBonusCard;
        public bool CanSell => HasBonusCard;

        partial void OnHasBonusCardChanged(bool value)
        {
            OnPropertyChanged(nameof(CanBuy));
            OnPropertyChanged(nameof(CanSell));
        }

        [RelayCommand]
        public void BuyBonusCard()
        {
            if (_global?.Client == null)
            {
                InfoMessage = "Je moet ingelogd zijn om een bonuskaart abonnement te kopen.";
                return;
            }

            if (HasBonusCard)
            {
                InfoMessage = "Je hebt al een lopend abonnement.";
                return;
            }

            HasBonusCard = true;
            _global.HasBonusCard = true;

            InfoMessage = $"succesvol geabonneerd voor €{Price:F2}.";
        }

        [RelayCommand]
        public void SellBonusCard()
        {
            if (_global?.Client == null)
            {
                InfoMessage = "Je moet ingelogd zijn om een bonuskaart abonnement op te zeggen.";
                return;
            }

            if (!HasBonusCard)
            {
                InfoMessage = "Je hebt geen lopend abonnement.";
                return;
            }

            HasBonusCard = false;
            _global.HasBonusCard = false;

            InfoMessage = $"je abonnement is succesvol opgezegd.";
        }
    }
}
