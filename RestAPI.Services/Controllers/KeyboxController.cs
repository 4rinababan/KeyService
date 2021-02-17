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
    public class KeyboxController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;

        [HttpPost]
        [ActionName("getKeybox")]
        public Response GetKeybox([FromBody]parameter param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetSingleKeybox", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = param.part_no;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = param.required_qty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = param.work_order_id;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = param.product_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get Keybox Key";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("KEYBOX" + i + " : " + value);
                    if (value == "this Product ID Alreaady Linked !") { response.success = false; response.message = value; response.save_data = null; }
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
        [ActionName("reserveKeybox")]
        public Response ReserveKeybox([FromBody]parameter2 param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ReserveKeybox", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = param.part_no;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = param.required_qty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = param.work_order_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Reserve Keybox Key";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("KEYBOX" + i + " : " + value);
                    if (value == "This WoID is already Reserve Key") { response.success = false; response.message = value; response.save_data = null; }
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
        [ActionName("getKeyboxByWoID")]
        public Response GetKeyboxByWoID([FromBody]parameter param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetKeyboxKey", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = param.part_no;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = param.required_qty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = param.work_order_id;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = param.product_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Get Keybox Key By Wo ID";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("KEYBOX" + i + " : " + value);
                    if (value == "this Product ID Alreaady Linked !") { response.success = false; response.message = value; response.save_data = null; }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return response;
        }

        [HttpPost]
        [ActionName("releaseKeybox")]
        public Response_message ReleaseKeybox([FromBody] ID param)
        {
            Response_message response = new Response_message();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_Release", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "KEYBOX";
                cmd.Parameters.Add("@productId", SqlDbType.VarChar).Value = param.product_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Release Keybox from product_id : " + param.product_id;
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return response;
        }
    }
}
