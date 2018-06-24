using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace AdminLibrary
{
    public class AdminDAO
    {
        private string strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

        public AdminDTO CheckLogin(string username, string password)
        {
            AdminDTO result = new AdminDTO();
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "SELECT * FROM Admin WHERE username = @username, password=@password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        string userid = dr.GetString(0);
                        string pw = dr.GetString(1);
                        string firstName = dr.GetString(2);
                        string lastName = dr.GetString(3);
                        string phone = dr.GetString(4);
                        string email = dr.GetString(5);
                        result = new AdminDTO(userid, pw, firstName, lastName, phone, email);
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return result; 
        }

    }
}
