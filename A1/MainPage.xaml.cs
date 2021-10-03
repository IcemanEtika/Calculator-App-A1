using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace A1
{
    public partial class MainPage : ContentPage
    {

        ObservableCollection<Product> products =
        new ObservableCollection<Product>
        {
                    new Product("Pants","20","20"),
                    new Product("Shoes", "50", "20"),
                    new Product("Hats","10","10"),
                    new Product("Tshirts", "10", "5"),
                    new Product("Dresses","24","24"),
        };

        ObservableCollection<History> purchases = new ObservableCollection<History> { };
        
        public MainPage()
        {
            InitializeComponent();
            myList.ItemsSource = products;
        }

        void myList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if ((e.SelectedItem as Product).name != null)
            {
                ProductType.Text = (e.SelectedItem as Product).name;

                if (Quantity.Text == "Quantity")
                {
                    Quantity.Text = "0";
                }

                Total.Text = "" + double.Parse((e.SelectedItem as Product).price) * double.Parse(Quantity.Text);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (Quantity.Text == "Quantity")
            {
                Quantity.Text = "0";
            }

            Quantity.Text = Quantity.Text == "0" ? Quantity.Text = button.Text : Quantity.Text += button.Text;

            if ((myList.SelectedItem as Product) != null )
            {
                Total.Text = "" + double.Parse((myList.SelectedItem as Product).price) * double.Parse(Quantity.Text);
            }
        }

        private async void Buy_Clicked(object sender, EventArgs e)
        {
            if (Total.Text == "Total" || Quantity.Text == "0")
            {
                await DisplayAlert("Error", "Please enter a valid quantity and choose an item before attempting to buy", "OK");
            }
            else
            {
                if (int.Parse((myList.SelectedItem as Product).quantity) < int.Parse(Quantity.Text))
                {
                    await DisplayAlert("Error", "Requested quantity exceeds amount available for product. Please enter a valid amount.", "OK");
                }
                else
                {
                    (myList.SelectedItem as Product).quantity = "" + (int.Parse((myList.SelectedItem as Product).quantity) - int.Parse(Quantity.Text));
                    purchases.Add(new History(ProductType.Text, Quantity.Text, Total.Text, DateTime.Now));
                    await DisplayAlert("Success", "Item has been purchased.", "OK");
                }
                Quantity.Text = "0";
                Total.Text = "0";
            }
        }

        private async void Manager_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manager(purchases, products));
        }
    }
}
