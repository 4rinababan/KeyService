using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestAPI.Services.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RestAPI.Services.LuhnAlgorithm;
using RestAPI.Services.Update;

namespace RestAPI.Services.Controllers
{
    public class GenerateKeysController : ApiController
    {
        UpdateIsgenerated update = new UpdateIsgenerated();
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;
        ImeiRanges imei_key = new ImeiRanges();
        MacRanges Mac_key = new MacRanges();
        KeyboxRanges keybox_key = new KeyboxRanges();
        AttestationKey attestation_key = new AttestationKey();
        public bool imei_generating = false;
        public bool mac_generating = false;
        public bool keybox_generating = false;
        public bool AttestationKey_generating = false;

        private ImeiRangesResponse GetImeiRangeId(int Id )
        {
            ImeiRangesResponse response = new ImeiRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getById";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<ImeiRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        imei_key.Id = Convert.ToInt32(reader[0]);
                        imei_key.Tacfac = Convert.ToInt32(reader[1]);
                        imei_key.Imeistart = Convert.ToInt32(reader[2]);
                        imei_key.Imeiend = Convert.ToInt32(reader[3]);
                        imei_key.Qty = Convert.ToInt32(reader[4]);
                        imei_key.CreatedBy = reader[5].ToString();
                        imei_key.CreatedOn = reader[6].ToString();
                        imei_key.UpdatedBy = reader[7].ToString();
                        imei_key.UpdateOn = reader[8].ToString();
                        imei_key.PartNo = reader[9].ToString();
                        imei_key.isGenerated = Convert.ToInt32(reader[10]);
                        response.save_data.Add(imei_key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + Id + " Not Found , Please check is Correct !";
                    response.save_data = null;
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        private macRangesResponse GetMacRangeId(int Id)
        {
            macRangesResponse response = new macRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getById";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<MacRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Mac_key.id = Convert.ToInt32(reader[0]);
                        Mac_key.mac_start = reader[1].ToString();
                        Mac_key.mac_end = reader[2].ToString();
                        Mac_key.qty = Convert.ToInt32(reader[3]);
                        Mac_key.created_by = reader[4].ToString();
                        Mac_key.created_on = reader[5].ToString();
                        Mac_key.updated_by = reader[6].ToString();
                        Mac_key.update_on = reader[7].ToString();
                        Mac_key.part_no = reader[8].ToString();
                        Mac_key.remarks = reader[9].ToString();
                        Mac_key.is_generated = Convert.ToInt32(reader[10]);
                        response.save_data.Add(Mac_key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + Id + " Not Found , Please check is Correct !";
                    response.save_data = null;
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        private keyboxRangesResponse GetKeyboxRangeId(int Id)
        {
            keyboxRangesResponse response = new keyboxRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_KeyboxRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getById";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<KeyboxRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        keybox_key.id = Convert.ToInt32(reader[0]);
                        keybox_key.root_path = reader[1].ToString();
                        keybox_key.preffix = reader[2].ToString();
                        keybox_key.keybox_start = reader[3].ToString();
                        keybox_key.keybox_end = reader[4].ToString();
                        keybox_key.file_extension = reader[5].ToString();
                        keybox_key.file_qty_per_directory = Convert.ToInt32(reader[6]);
                        keybox_key.qty = Convert.ToInt32(reader[7]);
                        keybox_key.created_by = reader[8].ToString();
                        keybox_key.created_on = reader[9].ToString();
                        keybox_key.updated_by = reader[10].ToString();
                        keybox_key.updated_on = reader[11].ToString();
                        keybox_key.part_no = reader[12].ToString();
                        keybox_key.is_generated = Convert.ToInt32(reader[13]);
                        response.save_data.Add(keybox_key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + Id + " Not Found , Please check is Correct !";
                    response.save_data = null;
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        private attestationKeyRangesResponse GetAttestationKeyRangeId(int Id)
        {
            attestationKeyRangesResponse response = new attestationKeyRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_AttestationKeyRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getById";
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<AttestationKey>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        attestation_key.id = Convert.ToInt32(reader[0]);
                        attestation_key.root_path = reader[1].ToString();
                        attestation_key.preffix = reader[2].ToString();
                        attestation_key.attestationkey_start = reader[3].ToString();
                        attestation_key.attestationkey_end = reader[4].ToString();
                        attestation_key.file_extension = reader[5].ToString();
                        attestation_key.file_qty_per_directory = Convert.ToInt32(reader[6]);
                        attestation_key.qty = Convert.ToInt32(reader[7]);
                        attestation_key.created_by = reader[8].ToString();
                        attestation_key.created_on = reader[9].ToString();
                        attestation_key.updated_by = reader[10].ToString();
                        attestation_key.updated_on = reader[11].ToString();
                        attestation_key.part_no = reader[12].ToString();
                        attestation_key.is_generated = Convert.ToInt32(reader[13]);
                        response.save_data.Add(attestation_key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + Id + " Not Found , Please check is Correct !";
                    response.save_data = null;
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        [HttpPost]
        [ActionName("generateImeiKeys")]
        public ImeiRangesMessage GenerateImeiKeys([FromBody] ID2 param)
        {
            ImeiRangesMessage response = new ImeiRangesMessage();
            GetImeiRangeId(param.Id);
            if (imei_generating==true) { response.success = false; response.message = "Generating is on progress.. Please until finish !"; return response; }
            if (imei_key.isGenerated == 1) { response.success = false; response.message = "This Id Already Generated !"; return response; }
            SqlConnection con = new SqlConnection(connection);
            imei_generating = true;
            for (int j = 0; j < imei_key.Qty; j++)
            {
                try
                {
                    if (con.State != ConnectionState.Open) { con.Close(); }
                    con.Open();
                    string imei = "00000" + (imei_key.Imeistart + j);
                    imei = imei.Substring(imei.Length - 6, 6);
                    imei = imei_key.Tacfac.ToString() + imei;
                    int valueImei;
                    valueImei = checkDigit.CalLuhnCheckDigit(imei);
                    imei = imei + valueImei;
                    SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "IMEI";
                    cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                    cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = imei;
                    cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    Console.Write("ERROR : " + ex);
                }
                finally
                {
                    con.Close();
                }    
            }
            response.success = true;
            response.message = "Success Generate " + imei_key.Qty + " Imei Key"; 
            imei_generating = false;
            update.UpdateImei(imei_key.Id);
            return response;
        }

        [HttpPost]
        [ActionName("generateMacKeys")]
        public macRangesMessage GenerateMacKeys([FromBody] ID2 param)
        {
            macRangesMessage response = new macRangesMessage();
            GetMacRangeId(param.Id);
            if (mac_generating == true) { response.success = false; response.message = "Generating is on progress.. Please until finish !"; return response; }
            if (Mac_key.is_generated == 1) { response.success = false; response.message = "This Id Already Generated !"; return response; }
            SqlConnection con = new SqlConnection(connection);
            mac_generating = true;
            Int64 toInt = Int64.Parse(Mac_key.mac_start, System.Globalization.NumberStyles.HexNumber)-1;
            string toHex = toInt.ToString("X");
            for (int j = 0; j < Mac_key.qty; j++)
            {
                try
                {
                    if (con.State != ConnectionState.Open) { con.Close(); }
                    con.Open();
                    Int64 intFromHex = Int64.Parse(toHex, System.Globalization.NumberStyles.HexNumber)+1;
                    string hexValue = intFromHex.ToString("X");
                    toHex = hexValue;
                    SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "MAC";
                    cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                    cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = hexValue;
                    cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    
                }
                catch (Exception ex)
                {
                    Console.Write("ERROR : " + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            response.success = true;
            response.message = "Success Generate " + Mac_key.qty + " Mac Key";
            mac_generating = false;
            update.UpdateMac(Mac_key.id);
            return response;
        }

        [HttpPost]
        [ActionName("generateKeybox")]
        public keyboxRangesMessage GenerateKeybox([FromBody] ID2 param)
        {
            keyboxRangesMessage response = new keyboxRangesMessage();
            checkFile check = new checkFile();
            GetKeyboxRangeId(param.Id);
            if (keybox_generating == true) { response.success = false; response.message = "Generating is on progress.. Please until finish !"; return response; }
            if (keybox_key.is_generated == 1) { response.success = false; response.message = "This Id Already Generated !"; return response; }
            SqlConnection con = new SqlConnection(connection);
            keybox_generating = true;
            if (!check.checkKeybox(keybox_key.root_path, keybox_key.preffix, keybox_key.keybox_start, keybox_key.keybox_end, keybox_key.file_extension, keybox_key.file_qty_per_directory, keybox_key.qty))
            {
                string Message = check.Message_keybox();
                response.success = false;
                response.message = Message;
                return response;
            }
                int mod = keybox_key.qty % keybox_key.file_qty_per_directory;
                int rounding = keybox_key.qty / keybox_key.file_qty_per_directory;
                int Istart = int.Parse(keybox_key.keybox_start);
                int Iend = int.Parse(keybox_key.keybox_end);

            for (int i = 0; i < rounding; i++)
            {
                string dir = "00000000000" + (Istart);
                dir = dir.Substring(dir.Length - 12, 12);
                string Path2 = keybox_key.root_path + "\\" + dir;
                for (int j = 0; j < keybox_key.file_qty_per_directory; j++)
                {
                    string keybox = "00000000000" + (Istart + j);
                    keybox = keybox.Substring(keybox.Length - 12, 12);
                    keybox = keybox_key.preffix + "_" + keybox + keybox_key.file_extension;

                    try
                    {
                        if (con.State != ConnectionState.Open) { con.Close(); }
                        con.Open();                      
                        SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "KEYBOX";
                        cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                        cmd.Parameters.Add("@path", SqlDbType.VarChar).Value = Path2;
                        cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = keybox;
                        cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("ERROR : " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                Istart = Istart + keybox_key.file_qty_per_directory;
            }

            if (mod != 0)
            {
                for (int i = 0; i < mod; i++)
                {
                    string dir = "00000000000" + (Istart);
                    dir = dir.Substring(dir.Length - 12, 12);
                    string Path2 = keybox_key.root_path + "\\" + dir;
                    string keybox = "00000000000" + (Istart + i);
                    keybox = keybox.Substring(keybox.Length - 12, 12);
                    keybox = keybox_key.preffix + "_" + keybox + keybox_key.file_extension;
                    try
                    {
                        if (con.State != ConnectionState.Open) { con.Close(); }
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "KEYBOX";
                        cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                        cmd.Parameters.Add("@path", SqlDbType.VarChar).Value = Path2;
                        cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = keybox;
                        cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("ERROR : " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            response.success = true;
            response.message = "Success Generate " + keybox_key.qty + " Keybox File";
            keybox_generating = false;
            update.UpdateKeybox(keybox_key.id);
            return response;
        }

        [HttpPost]
        [ActionName("generateAttestationKey")]
        public keyboxRangesMessage GenerateAttestationKey([FromBody] ID2 param)
        {
            keyboxRangesMessage response = new keyboxRangesMessage();
            checkFile check = new checkFile();
            GetAttestationKeyRangeId(param.Id);
            if (AttestationKey_generating == true) { response.success = false; response.message = "Generating is on progress.. Please until finish !"; return response; }
            if (attestation_key.is_generated == 1) { response.success = false; response.message = "This Id Already Generated !"; return response; }
            SqlConnection con = new SqlConnection(connection);
            AttestationKey_generating = true;
            if (!check.checkAttestationKey(attestation_key.root_path, attestation_key.preffix, attestation_key.attestationkey_start, attestation_key.attestationkey_end, attestation_key.file_extension, attestation_key.file_qty_per_directory, attestation_key.qty))
            {
                string Message = check.Message_AttKey();
                response.success = false;
                response.message = Message;
                return response;
            }
            int mod = attestation_key.qty % attestation_key.file_qty_per_directory;
            int rounding = attestation_key.qty / attestation_key.file_qty_per_directory;
            int Istart = int.Parse(attestation_key.attestationkey_start);
            int Iend = int.Parse(attestation_key.attestationkey_end);

            for (int i = 0; i < rounding; i++)
            {
                string dir = "00000000000" + (Istart);
                dir = dir.Substring(dir.Length - 12, 12);
                string Path2 = attestation_key.root_path + "\\" + dir;
                for (int j = 0; j < attestation_key.file_qty_per_directory; j++)
                {
                    string attestationKey = "00000000000" + (Istart + j);
                    attestationKey = attestationKey.Substring(attestationKey.Length - 12, 12);
                    attestationKey = attestation_key.preffix + "_" + attestationKey + attestation_key.file_extension;

                    try
                    {
                        if (con.State != ConnectionState.Open) { con.Close(); }
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "AttestationKey";
                        cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                        cmd.Parameters.Add("@path", SqlDbType.VarChar).Value = Path2;
                        cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = attestationKey;
                        cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("ERROR : " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                Istart = Istart + attestation_key.file_qty_per_directory;
            }

            if (mod != 0)
            {
                for (int i = 0; i < mod; i++)
                {
                    string dir = "00000000000" + (Istart);
                    dir = dir.Substring(dir.Length - 12, 12);
                    string Path2 = attestation_key.root_path + "\\" + dir;
                    string attestationkey = "00000000000" + (Istart + i);
                    attestationkey = attestationkey.Substring(attestationkey.Length - 12, 12);
                    attestationkey = attestation_key.preffix + "_" + attestationkey + attestation_key.file_extension;
                    try
                    {
                        if (con.State != ConnectionState.Open) { con.Close(); }
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "AttestationKey";
                        cmd.Parameters.Add("@RangeId", SqlDbType.VarChar).Value = param.Id;
                        cmd.Parameters.Add("@path", SqlDbType.VarChar).Value = Path2;
                        cmd.Parameters.Add("@keyValue", SqlDbType.VarChar).Value = attestationkey;
                        cmd.Parameters.Add("@badge", SqlDbType.VarChar).Value = param.badge;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("ERROR : " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            response.success = true;
            response.message = "Success Generate " + attestation_key.qty + " AttestationKey File";
            AttestationKey_generating = false;
            update.UpdateAttestationKey(attestation_key.id);
            return response;
        }
    }
}
