using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_API.Models
{
    public class pr_request
    {
        public int requestid { get; set; }

        public int ledger_id { get; set; }

        public string requested_user { get; set; }

        public string inserted_date { get; set; }

        public string pr_name { get; set; }

    }
}
