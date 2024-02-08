using System;

namespace Watches.Models

{
    public class watches
    {
        public watches() { }
        public int watch_id {  get; set; }
        public string model_name { get; set; }
        public string model_description { get; set;}
        public int manufacturer_id { get; set; }
        public string manufacturer_name { get; set; }
        public string price { get; set; }
        
    }
}
