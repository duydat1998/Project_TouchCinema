using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace MovieLibrary
{
    public class MovieDAO
    {
        private string strConnection;

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

    }
}
