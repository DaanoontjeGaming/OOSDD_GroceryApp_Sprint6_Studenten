using Grocery.App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = null; 

            Routing.RegisterRoute(nameof(GroceryListItemsView), typeof(GroceryListItemsView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(ChangeColorView), typeof(ChangeColorView));
            Routing.RegisterRoute("Login", typeof(LoginView));
            Routing.RegisterRoute(nameof(BestSellingProductsView), typeof(BestSellingProductsView));
            Routing.RegisterRoute(nameof(BoughtProductsView), typeof(BoughtProductsView));
            Routing.RegisterRoute(nameof(CategoriesView), typeof(CategoriesView));
            Routing.RegisterRoute(nameof(ProductCategoriesView), typeof(ProductCategoriesView));
            Routing.RegisterRoute(nameof(NewProductView), typeof(NewProductView));
            Routing.RegisterRoute(nameof(BonusCardView), typeof(BonusCardView));
        }
    }
}