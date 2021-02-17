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
    public class ImeiRangesController : ApiController
    {
        ImeiRanges key = new ImeiRanges();
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;
        private ImeiRangesResponse GetByTacfac(int tacfac)
        {
            ImeiRangesResponse response = new ImeiRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getByTacfac";
                cmd.Parameters.Add("@tacfac", SqlDbType.VarChar).Value = tacfac;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<ImeiRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        key.Tacfac = Convert.ToInt32(reader[0]);
                        key.Imeistart = Convert.ToInt32(reader[1]);
                        key.Imeiend = Convert.ToInt32(reader[2]);                     
                        response.save_data.Add(key);
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "ID : " + tacfac + " Not Found , Please check is Correct !";
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
        [ActionName("getALL")]
        public ImeiRangesResponse GetAll()
        {
            ImeiRangesResponse response = new ImeiRangesResponse();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "getAll";
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get All ImeiRanges";
                response.save_data = new List<ImeiRanges>();
                while (reader.Read())
                {
                    ImeiRanges _key = new ImeiRanges();
                    _key.Id = Convert.ToInt32(reader[0]);
                    _key.Tacfac = Convert.ToInt32(reader[1]);
                    _key.Imeistart = Convert.ToInt32(reader[2]);
                    _key.Imeiend = Convert.ToInt32(reader[3]);
                    _key.Qty = Convert.ToInt32(reader[4]);
                    _key.CreatedBy = reader[5].ToString();
                    _key.CreatedOn = reader[6].ToString();
                    _key.UpdatedBy = reader[7].ToString();
                    _key.UpdateOn = reader[8].ToString();
                    _key.PartNo = reader[9].ToString();
                    _key.isGenerated = Convert.ToInt32(reader[10]);
                   
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
        public ImeiRangesResponse GetById([FromBody]IR_Parameter param)
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
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = param.Id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get By ID";
                response.save_data = new List<ImeiRanges>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //ImeiRanges key = new ImeiRanges();
                        key.Id = Convert.ToInt32(reader[0]);
                        key.Tacfac = Convert.ToInt32(reader[1]);
                        key.Imeistart = Convert.ToInt32(reader[2]);
                        key.Imeiend = Convert.ToInt32(reader[3]);
                        key.Qty = Convert.ToInt32(reader[4]);
                        key.CreatedBy = reader[5].ToString();
                        key.CreatedOn = reader[6].ToString();
                        key.UpdatedBy = reader[7].ToString();
                        key.UpdateOn = reader[8].ToString();
                        key.PartNo = reader[9].ToString();
                        key.isGenerated = Convert.ToInt32(reader[10]);
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
        public ImeiRangesMessage UpdateImeiRanges([FromBody]IR_Parameter param)
        {
            GetById(param);
            ImeiRangesMessage response = new ImeiRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            if (key.isGenerated == 1)
            {
                response.success = false;
                response.message = "This Imei Ranges with ID : " + param.Id + " Already Generated !!!";
                return response;
            }
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Update"));
                cmd.Parameters.Add(new SqlParameter("@tacfac", param.tacfac));
                cmd.Parameters.Add(new SqlParameter("@from", param.imei_start));
                cmd.Parameters.Add(new SqlParameter("@end", param.imei_end));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                cmd.Parameters.Add(new SqlParameter("@id", param.Id));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Update Imei Ranges with ID : " + param.Id;
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
        public ImeiRangesMessage DeleteImeiRanges([FromBody]IR_Parameter param)
        {
            GetById(param); 
            ImeiRangesMessage response = new ImeiRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            try
            {

                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                if (key.isGenerated == 1)
                {
                    response.success = false;
                    response.message = "This Imei Ranges with ID : " + param.Id + " Already Generated !!!";
                    return response;
                }
                else
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@action", "Delete")); 
                    cmd.Parameters.Add(new SqlParameter("@id", param.Id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    response.success = true;
                    response.message = "Success Delete Imei Ranges with ID : " + param.Id;  
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
        public ImeiRangesMessage InsertImeiRanges([FromBody]IR_Parameter param)
        {
            GetByTacfac(param.tacfac);
            ImeiRangesMessage response = new ImeiRangesMessage();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ImeiRanges", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                var validQty = (param.imei_end - param.imei_start) + 1;

                if (param.tacfac.Equals(null) || param.badge == null)
                {
                    response.success = false;
                    response.message = "Data cannot null";
                    return response;
                }
                    if (param.imei_start.ToString().Length > 6 | param.imei_end.ToString().Length > 6)
                    {
                        response.success = false;
                        response.message = "Access Denied : Length Not Valid !";
                        return response;
                    }
                        if (key.Tacfac == param.tacfac)
                        {
                            if (key.Imeistart == param.imei_start | param.imei_end <= key.Imeiend)
                            {
                                response.success = false;
                                response.message = "Access Denied : Range Not Valid !";
                                return response;
                            }
                        }
                            if (param.qty > validQty)
                            {
                                response.success = false;
                                response.message = "Access Denied : Quantity cannot more Than : " + validQty;
                                return response;
                            }
                                if (param.qty < validQty)
                                {
                                    response.success = false;
                                    response.message = "Access Denied : Quantity cannot less : " + validQty;
                                    return response;
                                }
                string from = "00000" + param.imei_start;
                string end = "00000" + param.imei_end;
                from = from.Substring(from.Length - 6, 6);
                end = end.Substring(end.Length - 6, 6);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@action", "Insert"));
                cmd.Parameters.Add(new SqlParameter("@tacfac", param.tacfac));
                cmd.Parameters.Add(new SqlParameter("@from", from));
                cmd.Parameters.Add(new SqlParameter("@end", end));
                cmd.Parameters.Add(new SqlParameter("@qty", param.qty));
                cmd.Parameters.Add(new SqlParameter("@badge", param.badge));
                cmd.Parameters.Add(new SqlParameter("@partno", param.part_no));
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Insert Imei Ranges with tacfac : " + param.tacfac;
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
