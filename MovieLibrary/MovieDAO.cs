using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MovieLibrary
{
    public class MovieDAO
    {
        private string strConnection;

        //Nhớ xóa MayHieuBT để về lại ConnectionString cũ
        //ai dùng máy HieuBTSE62797 nhớ để thêm MayHieuBT
        public MovieDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;

        }

        public String GetMovieTitle(string movieID)
        {
            String movieName = "";
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select movieTitle from Movie where movieID=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", movieID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        movieName = reader["movieTitle"].ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return movieName;
        }

        public bool AddNewMovie(MovieLibrary.MovieDTO dto)
        {
            bool check = false;

            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "INSERT INTO Movie(movieID,movieTitle,length,rating,startDate,poster,linkTrailer,producer,year)" +
                    " VALUES(@movieID,@movieTitle,@length,@rating,@startDate,@poster,@linkTrailer,@producer,@year)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@movieID", dto.MovieID);
                cmd.Parameters.AddWithValue("@movieTitle", dto.MovieTitle);
                cmd.Parameters.AddWithValue("@length", dto.Length);
                cmd.Parameters.AddWithValue("@rating", dto.Rating);
                cmd.Parameters.AddWithValue("@startDate", dto.StartDate);
                cmd.Parameters.AddWithValue("@poster", dto.Poster);
                cmd.Parameters.AddWithValue("@linkTrailer", dto.LinkTrailer);
                cmd.Parameters.AddWithValue("@producer", dto.Producer);
                cmd.Parameters.AddWithValue("@year", dto.Year);
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

        public bool UpdateMovie(MovieLibrary.MovieDTO dto)
        {
            bool check = false;

            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "UPDATE Movie" +
                    " SET movieTitle=@movieTitle,length=@length,rating=@rating,startDate=@startDate,poster=@poster,linkTrailer=@linkTrailer,producer=@producer,year=@year" +
                    " WHERE movieID=@movieID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@movieTitle", dto.MovieTitle);
                cmd.Parameters.AddWithValue("@length", dto.Length);
                cmd.Parameters.AddWithValue("@rating", dto.Rating);
                cmd.Parameters.AddWithValue("@startDate", dto.StartDate);
                cmd.Parameters.AddWithValue("@poster", dto.Poster);
                cmd.Parameters.AddWithValue("@linkTrailer", dto.LinkTrailer);
                cmd.Parameters.AddWithValue("@producer", dto.Producer);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@movieID", dto.MovieID);
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

        public List<MovieDTO> SearchListMoiveMemberGuest(string movieName)
        {
            List<MovieDTO> listMovive = null;
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql="Select movieTitle, length, rating, startDate, poster, linkTrailer, producer, year " +
                            "From Movie " +
                            "Where movieTitle Like  @MovieName ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MovieName", "'%" + movieName + "%'");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listMovive = new List<MovieDTO>();
                    while (reader.Read())
                    {
                        
                        MovieDTO dto = new MovieDTO
                        {
                            MovieTitle = reader.GetString(0),
                            Length = reader.GetInt32(1),
                            Rating = reader.GetInt32(2),
                            StartDate = reader.GetDateTime(3),
                            Poster = reader.GetString(4),
                            LinkTrailer = reader.GetString(5),
                            Producer = reader.GetString(6),
                            Year = reader.GetInt32(7),
                        };
                        listMovive.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listMovive = null;
            }
            finally
            {
                con.Close();
            }
            return listMovive;
        }

        public DataSet getTopFiveMovie()
        {
            DataSet ds = null;
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "Select top(5) movieTitle, length, rating, startDate, poster, linkTrailer, producer, year " +
                            "From Movie " +
                            "Order by startDate desc ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);                
            }
            catch (Exception)
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public List<MovieDTO> GetMovieList()
        {
            List<MovieDTO> listMovie = new List<MovieDTO>();
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "SELECT movieID,movieTitle,[length],rating,startDate,poster,linkTrailer,producer,[year],genreID FROM Movie";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listMovie = new List<MovieDTO>();
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string title = reader.GetString(1);
                        int length = reader.GetInt32(2);
                        float rating = (float)reader.GetDouble(3);
                        DateTime dateTime = reader.GetDateTime(4);
                        string poster = "";
                        if (!reader.IsDBNull(5))
                        {
                            poster = reader.GetString(5);
                        }
                        string trailer="";
                        if (!reader.IsDBNull(6))
                        {
                            trailer =(string) reader.GetString(6);
                        }
                        string producer = reader.GetString(7);
                        int year = reader.GetInt32(8);
                        int genre = reader.GetInt32(9);
                        MovieDTO dto = new MovieDTO
                        {
                            MovieID = id,
                            MovieTitle = title,
                            Length = length,
                            Rating = rating,
                            StartDate = dateTime,
                            Poster = poster,
                            LinkTrailer = trailer,
                            Producer = producer,
                            Year = year,
                            Genre = genre
                        };
                        listMovie.Add(dto);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return listMovie;
        }

        public bool DeleteMovie(string movieID)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string sql = "DELETE FROM Movie WHERE movieID=@movieID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@movieID", movieID);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    check = true;
                }
            }
            finally
            {
                conn.Close();
            }

            return check;
        }
    }
}
