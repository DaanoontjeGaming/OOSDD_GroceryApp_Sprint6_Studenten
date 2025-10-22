using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class BonusCardView : ContentPage
{
    public BonusCardView(BonusCardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}