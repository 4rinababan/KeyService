using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Services.Models
{
    public class KeyServer
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Response
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<String> save_data { get; set; }
    }

    public class Response_message
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class parameter
    {
        public string part_no { get; set; }
        public int required_qty { get; set; }
        public int work_order_id { get; set; }
        public int product_id { get; set; }
    }

    public class parameter2
    {
        public string part_no { get; set; }
        public int required_qty { get; set; }
        public int work_order_id { get; set; }
    }

    public class ID
    {
        public int product_id { get; set; }
    }

    public class ID2
    {
        public int Id{ get; set; }
        public string badge { get; set; }
    }
}