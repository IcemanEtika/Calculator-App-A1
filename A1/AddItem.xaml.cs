using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        ObservableCollection<Product> products;

        public AddItem(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (ProductName.Text == null || ProductPrice.Text == null || ProductQuantity.Text == null ||
                ProductName.Text == "" || ProductPrice.Text == "" || ProductQuantity.Text == "")
            {
                await DisplayAlert("Error", "Please enter a valid product name, price and quantity", "OK");
            }
            else
            {
                products.Add(new Product(ProductName.Text, ProductQuantity.Text, ProductPrice.Text));
                await Navigation.PopAsync();
                await DisplayAlert("Done!", "New Product Added Successfully", "OK");
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}