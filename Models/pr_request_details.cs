using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_API.Models
{
    public class pr_request_details
    {
        public int pr_requestdetails { get; set; }

        public int item_id { get; set; }

        public int quantity { get; set; }

        public string price { get; set; }

        public int pr_request_id { get; set; }

        public string inserted_date { get; set; }

        public string status { get; set; }

    }
}
