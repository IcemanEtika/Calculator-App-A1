using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Restock : ContentPage
    {
        ObservableCollection<Product> products;
        public Restock(ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.products = products;
            itemList.ItemsSource = products;
        }

        private async void Restock_Clicked(object sender, EventArgs e)
        {
            if (itemList.SelectedItem == null || entry.Text == null || int.TryParse(entry.Text, out _) == false || entry.Text == "0")
            {
                await DisplayAlert("Error", "Please enter a valid quantity and choose a valid item before attempting to restock", "OK");
            }
            else
            {
                (itemList.SelectedItem as Product).quantity = "" + (int.Parse((itemList.SelectedItem as Product).quantity) + int.Parse(entry.Text));
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}