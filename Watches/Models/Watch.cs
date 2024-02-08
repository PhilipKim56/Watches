namespace Watches.Models
{
    public class watch
    {
        public watch() { }

        public int watch_id { get; set; }
        public int manufacturer_id { get; set; }
        public string model_name { get; set; }
        public int manufactured_year { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string manufacturer_name { get; set; }
        public IEnumerable<watches> Watches { get; set; }
        public string ImagePath { get; set; }

    }
}
