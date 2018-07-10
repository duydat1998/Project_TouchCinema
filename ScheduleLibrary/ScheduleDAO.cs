using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using UltilitiesLibrary;

namespace ScheduleLibrary
{
    public class ScheduleDAO
    {
        private string strConnection;

        public ScheduleDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();
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
                        float price = float.Parse(reader["priceOfTicket"].ToString());
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

        public List<ScheduleDTO> GetScheduleList()
        {
            List<ScheduleDTO> result = null;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select scheduleID, date, movieID, roomID, priceOfTicket from Schedule";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = new List<ScheduleDTO>();
                        while (reader.Read())
                        {
                            string id = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1);
                            string movieID = reader.GetString(2);
                            int roomID = reader.GetInt32(3);
                            float price = (float)reader.GetDouble(4);

                            ScheduleDTO dto = new ScheduleDTO()
                            {
                                ScheduleID = id,
                                ScheduleDate = date,
                                MovieID = movieID,
                                RoomID = roomID,
                                PriceOfTicket = price
                            };
                            result.Add(dto);
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public bool AddSchedule()
        {
            bool check = false;
            
            return check;
        }

        public List<ScheduleDTO> GetScheduleFromNowOn()
        {
            List<ScheduleDTO> result = new List<ScheduleDTO>();

            SqlConnection con = new SqlConnection(strConnection);
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "SELECT scheduleID, date, movieID, roomID, priceOfTicket from Schedule WHERE date >= CURRENT_TIMESTAMP";
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleDTO dto = new ScheduleDTO
                        {
                            ScheduleID = reader.GetString(0),
                            ScheduleDate = reader.GetDateTime(1),
                            MovieID = reader.GetString(2),
                            RoomID = reader.GetInt32(3),
                            PriceOfTicket = (float) reader.GetDouble(4)
                        };
                        result.Add(dto);
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
