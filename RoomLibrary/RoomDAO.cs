using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RoomLibrary
{
    public class RoomDAO
    {
        private string strConnection;

        public RoomDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;
        }

        public List<RoomDTO> GetRoomList()
        {
            List<RoomDTO> listRoom = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Select roomID, numberOfSear, isAvailable FROM Room";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listRoom = new List<RoomDTO>();
                    while (reader.Read())
                    {
                        RoomDTO dto = new RoomDTO
                        {
                            RoomID = reader.GetInt32(0),
                            NumberOfSeat = reader.GetInt32(1),
                            IsActive = reader.GetBoolean(2)
                        };
                        listRoom.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listRoom = null;
            }
            finally
            {
                con.Close();
            }
            return listRoom;
        }

        public bool UpdateRoomStatus(int roomid, int status)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Update Room set isAvailable=@isActive WHERE roomID=@RoomID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@RoomID", roomid);
                    cmd.Parameters.AddWithValue("@isActive", status);
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        result = true;
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public List<RoomDTO> GetRoomListForSchedule()
        {
            List<RoomDTO> listRoom = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "Select roomID FROM Room WHERE isAvailable = 1";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listRoom = new List<RoomDTO>();
                    while (reader.Read())
                    {
                        RoomDTO dto = new RoomDTO
                        {
                            RoomID = reader.GetInt32(0),
                            NumberOfSeat = reader.GetInt32(1),
                            IsActive = reader.GetBoolean(2)
                        };
                        listRoom.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listRoom = null;
            }
            finally
            {
                con.Close();
            }
            return listRoom;
        }
    }
}
