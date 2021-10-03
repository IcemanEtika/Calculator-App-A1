using System;

namespace A1
{
    public class History
    {
        public string name { get; set; }
        public string quantity { get; set; }
        public string total { get; set; }
        public DateTime date { get; set; }

        public History(string name, string quantity, string total, DateTime date)
        {
            this.name = name;
            this.quantity = quantity;
            this.total = total;
            this.date = date;
        }
    }
}
