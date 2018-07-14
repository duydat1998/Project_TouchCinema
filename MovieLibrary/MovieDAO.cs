using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using UltilitiesLibrary;

namespace MovieLibrary
{
    public class MovieDAO
    {
        private string strConnection;        
        
        public MovieDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();                        
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

        //This is just for Getting movie Genre
        public string getGenreName(int genreID)
        {
            string genreName = "";
            SqlConnection conn = new SqlConnection(strConnection);
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select genreName " +
                        "from Genre " +
                        "where genreID=@genreID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@genreID", genreID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        genreName = reader.GetString(0);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return genreName;
        }
        //

        public bool AddNewMovie(MovieLibrary.MovieDTO dto)
        {
            bool check = false;

            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "INSERT INTO Movie(movieID,movieTitle,length,rating,startDate,poster,linkTrailer,producer,year,genreID)" +
                    " VALUES(@movieID,@movieTitle,@length,@rating,@startDate,@poster,@linkTrailer,@producer,@year,@genreID)";
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
                cmd.Parameters.AddWithValue("@genreID", dto.Genre);
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
        
        public List<MovieDTO> getTopFiveLastestMovie()
        {
            List<MovieDTO> listMovie = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            try
            {
                string sql = "SELECT TOP(5) movieID,movieTitle,[length],rating,startDate,poster,linkTrailer,producer,[year],genreID  " +
                            "From Movie " +
                            "Order by startDate desc ";
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
                        string poster = "../Image/Poster/PosterNotAvailable(Default).jpg";
                        if (!reader.IsDBNull(5))
                        {
                            poster = reader.GetString(5);
                        }
                        string trailer = "";
                        if (!reader.IsDBNull(6))
                        {
                            trailer = (string)reader.GetString(6);
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
            catch (Exception)
            {
                listMovie = null;
            }
            finally
            {
                con.Close();
            }
            return listMovie;
        }

        public List<MovieDTO> getTopFiveRatingMovie()
        {
            List<MovieDTO> listMovie = null;
            SqlConnection con = new SqlConnection(strConnection);
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            try
            {
                string sql = "SELECT TOP(5) movieID,movieTitle,[length],rating,startDate,poster,linkTrailer,producer,[year],genreID  " +
                            "From Movie " +
                            "Order by rating desc ";
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
                        string poster = "../Image/Poster/PosterNotAvailable(Default).jpg";
                        if (!reader.IsDBNull(5))
                        {
                            poster = reader.GetString(5);
                        }
                        string trailer = "";
                        if (!reader.IsDBNull(6))
                        {
                            trailer = (string)reader.GetString(6);
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
            catch (Exception)
            {
                listMovie = null;
            }
            finally
            {
                con.Close();
            }
            return listMovie;
        }

        public List<MovieDTO> GetMovieList()
        {
            List<MovieDTO> listMovie = new List<MovieDTO>();
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "SELECT movieID,movieTitle,[length],rating,startDate,poster,linkTrailer,producer,[year],genreID " +
                            "FROM Movie";
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
                        string poster = "../Image/Poster/PosterNotAvailable(Default).jpg";
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

        public List<MovieDTO> GetMovieListForSchedule()
        {
            List<MovieDTO> listMovie = new List<MovieDTO>();
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "SELECT movieID " +
                            "FROM Movie";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listMovie = new List<MovieDTO>();
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        
                        MovieDTO dto = new MovieDTO
                        {
                            MovieID = id
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

        //Only Used at aspx.cs 
        public List<MovieDTO> getMovieDTO(List<MovieDTO> listMovie, string movieTitle)
        {
            List<MovieDTO> dto = new List<MovieDTO>();
            foreach (var item in listMovie)
            {
                if (item.MovieTitle.ToUpper().Equals(movieTitle.ToUpper()))
                {
                    dto.Add(item);
                }
            }
            return dto;
        }

        public List<MovieDTO> getMovieListByGenre(List<MovieDTO> listMovie, int movieGenreID, MovieDTO currentMovie)
        {
            List<MovieDTO> movieRefList = new List<MovieDTO>();
            foreach (var item in listMovie)
            {
                if (item.Genre == movieGenreID && item!= currentMovie)
                {
                    movieRefList.Add(item);
                }
            }
            return movieRefList;
        }

        public List<MovieDTO> getFiveMovieReference(List<MovieDTO> listMovie)
        {
            List<MovieDTO> movieList = new List<MovieDTO>();
            foreach (var item in listMovie)
            {
                movieList.Add(item);
                if (movieList.Count == 5)
                {
                    break;
                }
            }
            return movieList;
        }

        public List<MovieDTO> getMovieListByProducer(List<MovieDTO> listMovie, string movieProducer, MovieDTO currentMovie)
        {
            List<MovieDTO> movieList = new List<MovieDTO>();
            foreach (var item in listMovie)
            {
                if (item.Producer.ToUpper().Equals(movieProducer.ToUpper()) && item != currentMovie)
                {
                    movieList.Add(item);
                }
            }
            return movieList;
        }
        
        public List<MovieDTO> searchByName(List<MovieDTO> listMovie, string searchValue)
        {
            List<MovieDTO> resultList = new List<MovieDTO>();
            foreach (MovieDTO item in listMovie)
            {
                if (item.MovieTitle.ToUpper().Contains(searchValue.ToUpper()))
                {
                    resultList.Add(item);
                }

            }
            return resultList;
        }
        //
    }
}
