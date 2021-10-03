using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace A1
{
    public partial class Manager : ContentPage
    {
        ObservableCollection<History> purchases;
        ObservableCollection<Product> products;

        public Manager(ObservableCollection<History> purchases, ObservableCollection<Product> products)
        {
            InitializeComponent();
            this.purchases = purchases;
            this.products = products;
        }
        
        private async void History_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryView(purchases));
        }

        private async void Restock_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Restock(products));
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItem(products));
        }
    }
}