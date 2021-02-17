using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using RestAPI.Services.Models;

namespace RestAPI.Services.LuhnAlgorithm
{
    public class checkFile
    {
        keyboxRangesMessage response = new keyboxRangesMessage();
        public string message;
        public bool checkKeybox(string Path, string prefix, string start,string end, string ext,int fqty,int qty)
        {
            //string Path = @"D:\ARI\WebServices\test";
            //int qty, fqty;
            //qty = 20;
            //fqty = 8;
            int mod = qty % fqty;
            int rounding = qty / fqty;
            //string prefix = "test_1234";
            //string start = "000000000000";
            //string end = "000000000010";
            //string ext = ".txt";
            int Istart = int.Parse(start);
            int Iend = int.Parse(end);

            for (int i = 0; i < rounding; i++)
            {
                string dir = "00000000000" + (Istart);
                dir = dir.Substring(dir.Length - 12, 12);
                string Path2 = Path + "\\" + dir;
                if (!count(fqty, Istart, Path2, prefix, ext)) { return false; }
                Istart = Istart + fqty;
            }

            for (int i = 0; i < mod; i++)
            {
                string dir = "00000000000" + (Istart);
                dir = dir.Substring(dir.Length - 12, 12);
                string Path2 = Path + "\\" + dir;
                string imei = "00000000000" + (Istart + i);
                imei = imei.Substring(imei.Length - 12, 12);
                string root_path = Path2 + "\\" + prefix + "_" + imei + ext;
                if (!File.Exists(root_path))
                { message = "File : " + prefix + "_" + imei + ext+ "Not Exist !";return false; }     
            }
            return true;
        }

        public bool count(int fqty, int Istart, string Path, string prefix, string ext)
        {
            for (int i = 0; i < fqty; i++)
            {
                string imei = "00000000000" + (Istart + i);
                imei = imei.Substring(imei.Length - 12, 12);
                string root_path = Path + "\\" + prefix + "_" + imei + ext;
                if (!File.Exists(root_path))
                { message = "File : " + prefix + "_" + imei + ext + "Not Exist !";  return false; }
            }
            return true;
        }

        public string Message()
        {

            return message;
        }
    }
}