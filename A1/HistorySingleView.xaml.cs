using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorySingleView : ContentPage
    {
        public string title;
        public HistorySingleView(History history)
        {
            InitializeComponent();

            Title = history.name;
            ItemName.Text = history.name;
            ItemQuantity.Text = history.quantity;
            DatePurchased.Text = history.date.ToString("MM/dd/yyyy hh:mm:ss tt");
            TotalCost.Text += history.total;
        }
    }
}