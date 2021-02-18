using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Services.Models
{
    public class AttestationKey
    {
        public int id { get; set; }
        public string root_path { get; set; }
        public string preffix { get; set; }
        public string attestationkey_start { get; set; }
        public string attestationkey_end { get; set; }
        public string file_extension { get; set; }
        public int file_qty_per_directory { get; set; }
        public int qty { get; set; }
        public string created_by { get; set; }
        public string created_on { get; set; }
        public string updated_by { get; set; }
        public string updated_on { get; set; }
        public string part_no { get; set; }
        public int is_generated { get; set; }
    }

    public class attestationKeyRangesResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<AttestationKey> save_data { get; set; }
    }

    public class attestationKeyRangesMessage
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class AR_Parameter
    {
        public int id { get; set; }
        public string root_path { get; set; }
        public string preffix { get; set; }
        public string attestationkey_start { get; set; }
        public string attestationkey_end { get; set; }
        public string file_extension { get; set; }
        public int file_qty_per_directory { get; set; }
        public int qty { get; set; }
        public string badge { get; set; }
        public string part_no { get; set; }
        public int is_generated { get; set; }

    }
}