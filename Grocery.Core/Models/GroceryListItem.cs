using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class GroceryListItem : Model
    {
        public int GroceryListId { get; set; }
        public int ProductId { get; set; }
        [ObservableProperty]
        public int amount;
        public GroceryListItem(int id, int groceryListId, int productId, int amount) : base(id, "")
        {
            GroceryListId = groceryListId;
            ProductId = productId;
            Amount = amount;
        }
        private Product product = new(0, "None", 0);
        public Product Product
        {
            get => product;
            set
            {
                if (!EqualityComparer<Product>.Default.Equals(product, value))
                {
                    product = value;
                    OnPropertyChanged(nameof(Product));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public decimal TotalPrice => (Product?.Price ?? 0m) * Amount;

        partial void OnAmountChanged(int value)
        {
            OnPropertyChanged(nameof(TotalPrice));
        }
    }
}
