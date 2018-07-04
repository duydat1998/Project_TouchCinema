using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace GenreLibrary
{
    public class GenreDAO
    {
        private string strConnection;

        public GenreDAO()
        {
            strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;
        }

        public List<GenreDTO> GetGenreList()
        {
            List<GenreDTO> listGenre = null;
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            try
            {
                string sql = "Select genreID, genreName FROM Genre";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listGenre = new List<GenreDTO>();
                    while (reader.Read())
                    {
                        GenreDTO dto = new GenreDTO
                        {
                            GenreID = reader.GetInt32(0),
                            GenreName = reader.GetString(1)
                        };
                        listGenre.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listGenre = null;
            }
            finally
            {
                con.Close();
            }
            return listGenre;
        }
    }
}
