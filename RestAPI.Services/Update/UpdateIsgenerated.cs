using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RestAPI.Services.Update
{
    public class UpdateIsgenerated
    {
        string connection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public bool UpdateImei(int Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "UpdateImei";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            
            return true;
        }

        public bool UpdateMac(int Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GenerateKeys", con);
            try
            {
                if (con.State != ConnectionState.Open) { con.Close(); }
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "UpdateMac";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

            return true;
        }
    }

    
}