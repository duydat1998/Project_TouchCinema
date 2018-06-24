using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleLibrary
{
    public class ScheduleDAO
    {
        private string strConnection;

        public ScheduleDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

        }

        public ScheduleDTO GetScheduleByID(string scheduleID)
        {
            ScheduleDTO output = null;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select date, movieID, roomID, priceOfTicket from Schedule where scheduleID=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", scheduleID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime date = (DateTime) reader["date"];
                        string movieID = reader["movieID"].ToString();
                        int roomID = (int) reader["roomID"];
                        float price = (float)reader["priceOfTicket"];
                        output = new ScheduleDTO { ScheduleID = scheduleID, ScheduleDate = date, MovieID = movieID, RoomID = roomID, PriceOfTicket = price };
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return output;
        }


    }
}
