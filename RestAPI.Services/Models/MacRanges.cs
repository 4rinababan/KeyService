using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Services.Models
{
    public class MacRanges
    {
        public int id { get; set; }
        public string mac_start { get; set; }
        public string mac_end { get; set; }
        public int qty { get; set; }
        public string created_by { get; set; }
        public string created_on { get; set; }
        public string updated_by { get; set; }
        public string update_on { get; set; }
        public string remarks { get; set; }
        public string part_no { get; set; }
        public int is_generated { get; set; }
    }

    public class macRangesResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<MacRanges> save_data { get; set; }
    }

    public class macRangesMessage
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class MR_Parameter
    {
        public string mac_start { get; set; }
        public string mac_end { get; set; }
        public int qty { get; set; }
        public string badge { get; set; }
        public string part_no { get; set; }
        public string remarks { get; set; }
        public int Id { get; set; }
    }

    //public class MR_Parameter2
    //{
    //    public string mac_start { get; set; }
    //    public string mac_end { get; set; }
    //    public int qty { get; set; }
    //    public string badge { get; set; }
    //    public string part_no { get; set; }
    //    public string remarks { get; set; }
    //    public int Id { get; set; }
    //}

    //public class MR_Parameter3
    //{
    //    public int Id { get; set; }
    //}
}