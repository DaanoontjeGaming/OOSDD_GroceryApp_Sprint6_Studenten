using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        [ObservableProperty]
        bool cardOpgezegd = false;

        [ObservableProperty]
        DateTime expiryDate = DateTime.Now.AddYears(1);

        public BonusCardViewModel(GlobalViewModel global)
        {
            Title = "Bonuskaart";
            _global = global;
        }

        public bool CanBuy => !HasBonusCard;
        public bool CanCancel => HasBonusCard && !CardOpgezegd;
        public bool CanResume => HasBonusCard && CardOpgezegd;

        partial void OnHasBonusCardChanged(bool value)
        {
            OnPropertyChanged(nameof(CanBuy));
            OnPropertyChanged(nameof(CanCancel));
            OnPropertyChanged(nameof(CanResume));
        }

        partial void OnCardOpgezegdChanged(bool value)
        {
            OnPropertyChanged(nameof(CanCancel));
            OnPropertyChanged(nameof(CanResume));
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

            
            CardOpgezegd = false;
            _global.CardOpgezegd = false;

            ExpiryDate = DateTime.Now.AddYears(1);

            InfoMessage = $"Succesvol geabonneerd voor €{Price:F2}.";
        }

        [RelayCommand]
        public void BonusCardBehouden()
        {
            if (_global?.Client == null)
            {
                InfoMessage = "Je moet ingelogd zijn om deze actie uit te voeren.";
                return;
            }

           
            CardOpgezegd = false;
            _global.CardOpgezegd = false;

            InfoMessage = "Uw bonuskaart zal automatisch worden verlengd op de aangegeven datum.";
        }

        [RelayCommand]
        public void BonusCardOpgezegd()
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

            
            CardOpgezegd = true;
            _global.CardOpgezegd = true;

            InfoMessage = $"Je abonnement is succesvol opgezegd.";
        }
    }
}
