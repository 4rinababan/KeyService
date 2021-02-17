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
    public class AttestationKeyController : ApiController
    {
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        SqlTransaction trans = null;

        [HttpPost]
        [ActionName("getAttestationKey")]
        public Response GetAttestationKey([FromBody]parameter param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetSingleAttestationKey", con);
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
                response.message = "Success Get AttestationKey";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("AttestationKey" + i + " : " + value);
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
        [ActionName("reserveAttestationKey")]
        public Response ReserveAttestationKey([FromBody]parameter2 param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_ReserveATTKey", con);
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
                response.message = "Success Reserve AttestationKey";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("AttestationKey" + i + " : " + value);
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
        [ActionName("getAttestationKeyByWoID")]
        public Response GetAttestationKeyKeyByWoID([FromBody]parameter param)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetAttestationKey", con);
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
                response.message = "Success Get AttestationKey By Wo ID";
                response.save_data = new List<String>();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    string value = reader[0].ToString();
                    response.save_data.Add("AttestationKey" + i + " : " + value);
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
        [ActionName("releaseAttestationKey")]
        public Response_message ReleaseAttestationKey([FromBody] ID param)
        {
            Response_message response = new Response_message();
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_Release", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "AttestationKey";
                cmd.Parameters.Add("@productId", SqlDbType.VarChar).Value = param.product_id;
                SqlDataReader reader = cmd.ExecuteReader();
                response.success = true;
                response.message = "Success Release AttestationKey from product_id : " + param.product_id;
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
