using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ServerKey.Services
{
    /// <summary>
    /// Summary description for KeyServices
    /// </summary>
    [WebService()]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class KeyServices : System.Web.Services.WebService
    {

        #region KeyServer_Services
        [WebMethod]
        public String GetImeiKey(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetSingleImeiKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                //System.Threading.Thread.Sleep(15);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
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
        
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetMacKey(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetSingleMacKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetKeybox(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetSingleKeybox", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetAttestationKey(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetSingleAttestationKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String ReserveImeiKey(string PartNo, string requiredQty, string WorkOrderID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_ReserveImeiKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID; 
                da.Fill(ds);
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
            
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String ReserveMacKey(string PartNo, string requiredQty, string WorkOrderID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_ReserveMacKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String ReserveKeybox(string PartNo, string requiredQty, string WorkOrderID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_ReserveKeybox", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String ReserveAttestationKey(string PartNo, string requiredQty, string WorkOrderID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_ReserveATTKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                da.Fill(ds);
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

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetImeiKeyByWoID(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetImeiKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetMacKeyByWoID(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetMacKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetKeyBoxKeyByWoID(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetKeyboxKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod]
        public String GetAttestationKeyByWoID(string PartNo, string requiredQty, string WorkOrderID, string ProductID)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_GetAttestationKey", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = PartNo;
                cmd.Parameters.Add("@requiredQty", SqlDbType.VarChar).Value = requiredQty;
                cmd.Parameters.Add("@WorkOrderID", SqlDbType.VarChar).Value = WorkOrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;
                da.Fill(ds);
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        #endregion

        #region IndexingData_Services

        [WebMethod]
        public String RecompileIndex()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connection);
            SqlTransaction trans = null;
            SqlCommand cmd = new SqlCommand("sp_ReCompileIndex", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure; 
                da.Fill(ds);
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.Write("ERROR : " + ex);
            }
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        #endregion
    }
}
