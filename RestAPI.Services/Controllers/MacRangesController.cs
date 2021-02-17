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
    public class MacRangesController : ApiController
    {
        MacRanges key = new MacRanges();
        macRangesMessage responseValidation = new macRangesMessage();
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;

        public static bool BetweenRanges(Int64 a, Int64 b, Int64 ranges)
        {
            return (a <= ranges && ranges <= b);
        }

        private bool validation(string macStart, string macEnd,int qty)
        {
            //macRangesMessage response = new macRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getAll";
                SqlDataReader reader = cmd.ExecuteReader();
                //response.success = true;
                //response.message = "Success Get All Macranges";
                //response.save_data = new List<MacRanges>();
                while (reader.Read())
                {
                    MacRanges _key = new MacRanges();
                    _key.mac_start = reader[1].ToString();
                    _key.mac_end = reader[2].ToString();
                    Int64 _MacStart = Convert.ToInt64(_key.mac_start, 16);
                    Int64 _MacEnd = Convert.ToInt64(_key.mac_end, 16);
                    Int64 start = Convert.ToInt64(macStart, 16);
                    Int64 end = Convert.ToInt64(macEnd, 16);
                    Int64 validQty = (end - start) + 1;
                    if (BetweenRanges(_MacStart, _MacEnd,start )){ responseValidation.success = false; responseValidation.message = "Range mac_start Not Valid";return true; }
                    if (BetweenRanges(_MacStart, _MacEnd, end)) { responseValidation.success = false; responseValidation.message = "Range mac_end Not Valid"; return true; }
                    if(qty < validQty) { responseValidation.success = false; responseValidation.message = "Quantity cannot less  : "+validQty; return true; }
                    if(qty > validQty) { responseValidation.success = false; responseValidation.message = "Quantity cannot more than : " + validQty; return true; }
                    //response.save_data.Add(_key);
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
            return false;
        }

        [HttpGet]
        [ActionName("getALL")]
        public macRangesResponse GetAll()
        {
            macRangesResponse response = new macRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getAll";
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get All MacRanges";
                response.save_data = new List<MacRanges>();
                while (reader.Read())
                {
                    MacRanges _key = new MacRanges();
                    _key.id = Convert.ToInt32(reader[0]);
                    _key.mac_start = reader[1].ToString();
                    _key.mac_end = reader[2].ToString();
                    _key.qty = Convert.ToInt32(reader[3]);
                    _key.created_by = reader[4].ToString();
                    _key.created_on = reader[5].ToString();
                    _key.updated_by = reader[6].ToString();
                    _key.update_on = reader[7].ToString();
                    _key.remarks = reader[8].ToString();
                    _key.part_no = reader[9].ToString();
                    _key.is_generated = Convert.ToInt32(reader[10]);

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
        public macRangesResponse GetById([FromBody]MR_Parameter2 param)
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
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = param.Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<MacRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       
                        key.id = Convert.ToInt32(reader[0]);
                        key.mac_start = reader[1].ToString();
                        key.mac_end = reader[2].ToString();
                        key.qty = Convert.ToInt32(reader[3]);
                        key.created_by = reader[4].ToString();
                        key.created_on = reader[5].ToString();
                        key.updated_by = reader[6].ToString();
                        key.update_on = reader[7].ToString();
                        key.remarks = reader[8].ToString();
                        key.part_no = reader[9].ToString();
                        key.is_generated = Convert.ToInt32(reader[10]);
                        response.save_data.Add(key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + param.Id + " Not Found , Please check is Correct !";
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
        public macRangesMessage UpdateMacRanges([FromBody]MR_Parameter2 param)
        {
            GetById(param);
            macRangesMessage response = new macRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if (key.is_generated == 1)
                {
                    response.success = false;
                    response.message = "This Mac Ranges with ID : " + param.Id + " Already Generated !!!";
                    return response;
                }
                if (param.mac_start != key.mac_start && param.mac_end != key.mac_end)
                {
                    if (validation(param.mac_start, param.mac_end, param.qty))
                    {
                        return responseValidation;
                    }
                }
                else
               
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Update"));
                cmd.Parameters.Add(new SqlParameter("@from", param.mac_start));
                cmd.Parameters.Add(new SqlParameter("@end", param.mac_end));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                cmd.Parameters.Add(new SqlParameter("@id", param.Id));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Update Mac Ranges with ID : " + param.Id;
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
        public macRangesMessage DeleteMacRanges([FromBody]MR_Parameter2 param)
        {
            GetById(param);
            macRangesMessage response = new macRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                if (key.is_generated == 1)
                {
                    response.success = false;
                    response.message = "This Mac Ranges with ID : " + param.Id + " Already Generated !!!";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@action", "Delete"));
                    cmd.Parameters.Add(new SqlParameter("@id", param.Id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    response.success = true;
                    response.message = "Success Delete mac Ranges with ID : " + param.Id;
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
        public macRangesMessage InsertMacRanges([FromBody]MR_Parameter param)
        {

            macRangesMessage response = new macRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_MacRanges", con);
            try
            {
                if(validation(param.mac_start, param.mac_end, param.qty))
                {
                    return responseValidation;
                }
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                //macRangesMessage response = new macRangesMessage();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Insert"));
                cmd.Parameters.Add(new SqlParameter("@from", param.mac_start));
                cmd.Parameters.Add(new SqlParameter("@end", param.mac_end));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@remarks", param.remarks));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Insert Mac Ranges " ;
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
