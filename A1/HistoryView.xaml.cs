using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryView : ContentPage
    {
        public HistoryView(ObservableCollection<History> purchases)
        {
            InitializeComponent();
            historyList.ItemsSource = purchases;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            historyList.SelectedItem = null;
        }
        private async void historyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (historyList.SelectedItem != null)
            {
                await Navigation.PushAsync(new HistorySingleView(e.SelectedItem as History));
            }
        }
    }
}