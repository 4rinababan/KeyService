using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RestAPI.Services.LuhnAlgorithm
{
    public class checkFile
    {
        public string message_keybox;
        public string message;
        public bool checkKeybox(string Path, string prefix, string start,string end, string ext,int fqty,int qty)
        {
            int mod = qty % fqty;
            int rounding = qty / fqty;
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

            if (mod != 0)
            {
                for (int i = 0; i < mod; i++)
                {
                    string dir = "00000000000" + (Istart);
                    dir = dir.Substring(dir.Length - 12, 12);
                    string Path2 = Path + "\\" + dir;
                    string keybox = "00000000000" + (Istart + i);
                    keybox = keybox.Substring(keybox.Length - 12, 12);
                    string root_path = Path2 + "\\" + prefix + "_" + keybox + ext;
                    if (!File.Exists(root_path))
                    { message_keybox = "File : " + prefix + "_" + keybox + ext + " Not Exist !"; return false; }
                }
            }           
            return true;
        }

        public bool checkAttestationKey(string Path, string prefix, string start, string end, string ext, int fqty, int qty)
        {
            int mod = qty % fqty;
            int rounding = qty / fqty;
            int Istart = int.Parse(start);
            int Iend = int.Parse(end);

            for (int i = 0; i < rounding; i++)
            {
                string dir = "00000000000" + (Istart);
                dir = dir.Substring(dir.Length - 12, 12);
                string Path2 = Path + "\\" + dir;
                if (!count2(fqty, Istart, Path2, prefix, ext)) { return false; }
                Istart = Istart + fqty;
            }

            if (mod != 0)
            {
                for (int i = 0; i < mod; i++)
                {
                    string dir = "00000000000" + (Istart);
                    dir = dir.Substring(dir.Length - 12, 12);
                    string Path2 = Path + "\\" + dir;
                    string AttestationKey = "00000000000" + (Istart + i);
                    AttestationKey = AttestationKey.Substring(AttestationKey.Length - 12, 12);
                    string root_path = Path2 + "\\" + prefix + "_" + AttestationKey + ext;
                    if (!File.Exists(root_path))
                    { message = "File : " + prefix + "_" + AttestationKey + ext + " Not Exist !"; return false; }
                }
            }
            return true;
        }

        public bool count(int fqty, int Istart, string Path, string prefix, string ext)
        {
            for (int i = 0; i < fqty; i++)
            {
                string keybox = "00000000000" + (Istart + i);
                keybox = keybox.Substring(keybox.Length - 12, 12);
                string root_path = Path + "\\" + prefix + "_" + keybox + ext;
                if (!File.Exists(root_path))
                { message_keybox = "File : " + prefix + "_" + keybox + ext + " Not Exist !";  return false; }
            }
            return true;
        }

        public bool count2(int fqty, int Istart, string Path, string prefix, string ext)
        {
            for (int i = 0; i < fqty; i++)
            {
                string AttestationKey = "00000000000" + (Istart + i);
                AttestationKey = AttestationKey.Substring(AttestationKey.Length - 12, 12);
                string root_path = Path + "\\" + prefix + "_" + AttestationKey + ext;
                if (!File.Exists(root_path))
                { message = "File : " + prefix + "_" + AttestationKey + ext + " Not Exist !"; return false; }
            }
            return true;
        }

        public string Message_keybox()
        {
            return message_keybox;
        }

        public string Message_AttKey()
        {
            return message;
        }
    }
}