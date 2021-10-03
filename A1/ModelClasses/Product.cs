using System.ComponentModel;

namespace A1
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _quantity;
        public string name { get; set; }
        public string quantity {
            get { return _quantity; }
            set
            {
                if (value == _quantity)
                    return;
           
                _quantity = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(quantity)));
            }
        }
        public string price { get; set; }

        public Product()
        {
        }

        public Product(string name, string quantity, string price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
