using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_API.Models
{
    public class Items
    {

        public int itemid { get; set; }

        public string itemname { get; set; }
        
        public string units { get; set; }
    
        public string price { get; set; }
        public string op_quantity { get; set; }

        public string inserted_date { get; set; }

        public string item_group { get; set; }
    }
}
