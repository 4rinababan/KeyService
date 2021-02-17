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
    public class MacController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;

        [HttpPost]
        [ActionName("getMacKey")]
        public Response GetMacKey([FromBody] parameter param)
        {   
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetSingleMacKey", con);
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
                response.message = "Success Get Mac Key";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("MAC" + i + " : " + value);
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
        [ActionName("reserveMacKey")]
        public Response ReserveMacKey([FromBody]parameter2 param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ReserveMacKey", con);
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
                response.message = "Success Reserve Mac Key";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("MAC" + i + " : " + value);
                    if (value == "This Work Order ID is already Reserve Key") { response.success = false; response.message = value; response.save_data = null; }
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
        [ActionName("getMacKeyByWoID")]
        public Response GetMacKeyByWoID([FromBody]parameter param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetMacKey", con);
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
                response.message = "Success Get Mac Key By Wo ID";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("MAC" + i + " : " + value);
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
        [ActionName("releaseMacKey")]
        public Response_message ReleaseMacKey([FromBody] ID param)
        {
            Response_message response = new Response_message();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_Release", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "MAC";
                cmd.Parameters.Add("@productId", SqlDbType.VarChar).Value = param.product_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Release Mac from product_id : " + param.product_id;
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
