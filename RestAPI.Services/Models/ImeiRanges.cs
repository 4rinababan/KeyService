using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Services.Models
{
    public class ImeiRanges
    {
        public int Id { get; set; }
        public int Tacfac { get; set; }
        public Int32 Imeistart { get; set; }
        public int Imeiend { get; set; }
        public int Qty { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdateOn { get; set; }
        public string PartNo { get; set; }
        public int isGenerated { get; set; }

    }

    public class ImeiRangesResponse
    {
        public bool success { get; set; } 
        public string message { get; set; }
        public List<ImeiRanges> save_data { get; set; }
    }

    public class ImeiRangesMessage
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class IR_Parameter
    {
        public int tacfac { get; set; }
        public Int32 imei_start { get; set; }
        public Int32 imei_end { get; set; }
        public int qty { get; set; }
        public string badge { get; set; }
        public string part_no { get; set; }
        public int Id { get; set; } 
    }

    public class IR_Parameter2
    {
        public int Id { get; set; }
    }

    public class IR_Parameter3
    {
        public int tacfac { get; set; }
    }
}