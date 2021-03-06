﻿using System;
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

        public List<ScheduleDTO> GetScheduleListByMovieID(string movieID)
        {
            List<ScheduleDTO> result = new List<ScheduleDTO>();
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select scheduleID, date, movieID, roomID, priceOfTicket from Schedule WHERE movieID = @movieID order by date asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@movieID", movieID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = new List<ScheduleDTO>();
                        while (reader.Read())
                        {
                            string id = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1);
                            string mID = reader.GetString(2);
                            int roomID = reader.GetInt32(3);
                            float price = (float)reader.GetDouble(4);

                            ScheduleDTO dto = new ScheduleDTO()
                            {
                                ScheduleID = id,
                                ScheduleDate = date,
                                MovieID = mID,
                                RoomID = roomID,
                                PriceOfTicket = price
                            };
                            result.Add(dto);
                        }
                    }
                    
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
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
                    string sql = "Select scheduleID, date, movieID, roomID from Schedule";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = new List<ScheduleDTO>();
                        while (reader.Read())
                        {
                            string id = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1);
                            string mID = reader.GetString(2);
                            int roomID = reader.GetInt32(3);

                            ScheduleDTO dto = new ScheduleDTO()
                            {
                                ScheduleID = id,
                                ScheduleDate = date,
                                MovieID = mID,
                                RoomID = roomID
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
                string sql = "SELECT scheduleID, date, movieID, roomID, priceOfTicket from Schedule WHERE date >= CURRENT_TIMESTAMP Order by date asc";
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

        public bool AddSchedule(ScheduleDTO dto)
        {
            bool check = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "INSERT INTO Schedule(scheduleID,date,movieID,roomID,priceOfTicket) VALUES(@ID,@date,@movieID,@roomID,@price)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", dto.ScheduleID);
                cmd.Parameters.AddWithValue("@date", dto.ScheduleDate);
                cmd.Parameters.AddWithValue("@movieID", dto.MovieID);
                cmd.Parameters.AddWithValue("@roomID", dto.RoomID);
                cmd.Parameters.AddWithValue("@price", dto.PriceOfTicket);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    check = true;
                }
            }
            finally
            {
                con.Close();
            }


            return check;
        }

        public bool UpdateSchedule(ScheduleDTO dto)
        {
            bool check = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "UPDATE Schedule SET date=@date, movieID = @movieID,roomID = @roomID, priceOfTicket=@price WHERE scheduleID = @scheduleID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@date", dto.ScheduleDate);
                cmd.Parameters.AddWithValue("@movieID", dto.MovieID);
                cmd.Parameters.AddWithValue("@roomID", dto.RoomID);
                cmd.Parameters.AddWithValue("@price", dto.PriceOfTicket);
                cmd.Parameters.AddWithValue("@scheduleID", dto.ScheduleID);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    check = true;
                }
            }
            finally
            {
                con.Close();
            }
            return check;
        }

        public bool DeleteSchedule(string scheduleID)
        {
            bool check = false;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "DELETE FROM Schedule WHERE scheduleID = @scheduleID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@scheduleID", scheduleID);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    check = true;
                }
            }
            finally
            {
                con.Close();
            }
            return check;
        }

        //For webpages only
        public List<ScheduleDTO> getSpecificMovieSchedule(List<ScheduleDTO> FullScheduleList, string movieID)
        {
            List<ScheduleDTO> result = new List<ScheduleDTO>();
            foreach (var item in FullScheduleList)
            {
                if (item.MovieID.ToUpper().Equals(movieID.ToUpper()))
                {
                    result.Add(item);
                    if(result.Count == 8)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public ScheduleDTO GetScheduleDTO(List<ScheduleDTO> ScheduleList, string scheduleID)
        {
            ScheduleDTO dto = null;
            foreach (var item in ScheduleList)
            {
                if (item.ScheduleID.ToUpper().Equals(scheduleID.ToUpper()))
                {
                    dto = item;
                    break;
                }
            }
            return dto;
        }


        public void AdminScheduleDelete(string movieID)
        {
            
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string sql = "DELETE FROM Schedule WHERE movieID=@movieID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@movieID", movieID);
                int i = cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
