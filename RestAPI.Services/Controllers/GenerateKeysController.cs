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
        public bool imei_generating = false;
        public bool mac_generating = false;
        public bool keybox_generating = false;

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

        [HttpPost]
        [ActionName("generateImeiKeys")]
        public ImeiRangesMessage GenerateImeiKeys([FromBody] ID2 param)
        {
            ImeiRangesMessage response = new ImeiRangesMessage();
            GetImeiRangeId(param.Id);
            if (imei_generating==true) { response.success = false; response.message = "Generating is on progress.. Please until finish !"; return response; }
            if (imei_key.isGenerated == 1) { response.success = false; response.message = "This Id Already Generated !"; return response; }
            SqlConnection con = new SqlConnection(connection);   
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


            //for (int j = 0; j < Mac_key.qty; j++)
            //{
                try
                {
                if (check.checkKeybox(keybox_key.root_path, keybox_key.preffix, keybox_key.keybox_start, keybox_key.keybox_end, keybox_key.file_extension, keybox_key.file_qty_per_directory, keybox_key.qty))
                {
                    response.success = true;
                    response.message = "Success Generate " + keybox_key.qty + " Keybox File";
                    mac_generating = false;
                }
               

                }
                catch (Exception ex)
                {
                    Console.Write("ERROR : " + ex);
                }
                finally
                {
                    con.Close();
                }
            //}
            
            //update.UpdateMac(Mac_key.id);
            return response;

        }
    }
}
