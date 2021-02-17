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

namespace RestAPI.Services.Controllers
{
    public class KeyboxRangesController : ApiController
    {
        KeyboxRanges key = new KeyboxRanges();
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;      

        [HttpGet]
        [ActionName("getALL")]
        public keyboxRangesResponse GetAll()
        {
            keyboxRangesResponse response = new keyboxRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_KeyboxRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getAll";
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get All KeyboxRanges";
                response.save_data = new List<KeyboxRanges>();
                while (reader.Read())
                {
                    KeyboxRanges _key = new KeyboxRanges();
                    _key.id = Convert.ToInt32(reader[0]);
                    _key.root_path = reader[1].ToString();
                    _key.preffix = reader[2].ToString();
                    _key.keybox_start = reader[3].ToString();
                    _key.keybox_end = reader[4].ToString();
                    _key.file_extension = reader[5].ToString();
                    _key.file_qty_per_directory = Convert.ToInt32(reader[6]);
                    _key.qty = Convert.ToInt32(reader[7]);
                    _key.created_by = reader[8].ToString();
                    _key.created_on = reader[9].ToString();
                    _key.updated_by = reader[10].ToString();
                    _key.updated_on = reader[11].ToString();
                    _key.part_no = reader[12].ToString();
                    _key.is_generated = Convert.ToInt32(reader[13]);

                    response.save_data.Add(_key);
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

        [HttpGet]
        [ActionName("getById")]
        public keyboxRangesResponse GetById([FromBody]KR_Parameter param)
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
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = param.id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<KeyboxRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        KeyboxRanges _key = new KeyboxRanges();
                        _key.id = Convert.ToInt32(reader[0]);
                        _key.root_path = reader[1].ToString();
                        _key.preffix = reader[2].ToString();
                        _key.keybox_start = reader[3].ToString();
                        _key.keybox_end = reader[4].ToString();
                        _key.file_extension = reader[5].ToString();
                        _key.file_qty_per_directory = Convert.ToInt32(reader[6]);
                        _key.qty = Convert.ToInt32(reader[7]);
                        _key.created_by = reader[8].ToString();
                        _key.created_on = reader[9].ToString();
                        _key.updated_by = reader[10].ToString();
                        _key.updated_on = reader[11].ToString();
                        _key.part_no = reader[12].ToString();
                        _key.is_generated = Convert.ToInt32(reader[13]);
                        response.save_data.Add(_key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + param.id + " Not Found , Please check is Correct !";
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

        [HttpPut]
        [ActionName("update")]
        public keyboxRangesMessage UpdateKeyboxRanges([FromBody]KR_Parameter param)
        {
            GetById(param);
            keyboxRangesMessage response = new keyboxRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_KeyboxRanges", con);
            try
            {
                if (key.is_generated == 1)
                {
                    response.success = false;
                    response.message = "This Keybox Ranges with ID : " + param.id + " Already Generated !!!";
                    return response;
                }              
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Update"));
                cmd.Parameters.Add(new SqlParameter("@rootpath", param.root_path));
                cmd.Parameters.Add(new SqlParameter("@preffix", param.preffix));
                cmd.Parameters.Add(new SqlParameter("@from", param.keybox_start));
                cmd.Parameters.Add(new SqlParameter("@end", param.keybox_end));
                cmd.Parameters.Add(new SqlParameter("@ext", param.file_extension));
                cmd.Parameters.Add(new SqlParameter("@qtyperdir", param.file_qty_per_directory));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                cmd.Parameters.Add(new SqlParameter("@id", param.id));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Update Keybox Ranges with ID : " + param.id;
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

        [HttpDelete]
        [ActionName("delete")]
        public keyboxRangesMessage DeleteKeyboxRanges([FromBody]KR_Parameter param)
        {
            GetById(param);
            keyboxRangesMessage response = new keyboxRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_KeyboxRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                if (key.is_generated == 1)
                {
                    response.success = false;
                    response.message = "This Keybox Ranges with ID : " + param.id + " Already Generated !!!";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@action", "Delete"));
                    cmd.Parameters.Add(new SqlParameter("@id", param.id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    response.success = true;
                    response.message = "Success Delete Keybox Ranges with ID : " + param.id;
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
        [ActionName("Insert")]
        public keyboxRangesMessage InsertKeyboxRanges([FromBody]KR_Parameter param)
        {

            keyboxRangesMessage response = new keyboxRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_KeyboxRanges", con);
            try
            {               
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Insert"));
                cmd.Parameters.Add(new SqlParameter("@rootpath", param.root_path));
                cmd.Parameters.Add(new SqlParameter("@preffix", param.preffix));
                cmd.Parameters.Add(new SqlParameter("@from", param.keybox_start));
                cmd.Parameters.Add(new SqlParameter("@end", param.keybox_end));
                cmd.Parameters.Add(new SqlParameter("@ext", param.file_extension));
                cmd.Parameters.Add(new SqlParameter("@qtyperdir", param.file_qty_per_directory));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Insert Keybox Ranges ";
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
    }
}
