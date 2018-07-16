using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UltilitiesLibrary;

namespace PromotionLibrary
{
    public class PromotionDAO
    {
        private string strConnection;
        public PromotionDAO()
        {
            DatabaseConnection dc = new DatabaseConnection();
            strConnection = dc.GetConnection();
        }

        public bool AddPromotion(PromotionDTO dto)
        {
            bool check = false;

            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "INSERT INTO Promotion(code,name,active) VALUES(@code,@name,@active)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@code", dto.Code);
                cmd.Parameters.AddWithValue("@name", dto.Name);
                cmd.Parameters.AddWithValue("@active", dto.Active);
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

        public bool UpdateActivePromotion(string code,int active)
        {
            bool check = false;

            SqlConnection con = new SqlConnection(strConnection);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                string sql = "UPDATE Promotion SET active=@active WHERE code = @code";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@code",code);
                cmd.Parameters.AddWithValue("@active", active);
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

        public List<PromotionDTO> SearchPromotionByName(string name)
        {
            List<PromotionDTO> result = new List<PromotionDTO>();

            SqlConnection conn = new SqlConnection(strConnection);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string sql = "Select code,name,active FROM Promotion WHERE name LIKE @name";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PromotionDTO dto = new PromotionDTO
                        {
                            Code = reader.GetString(0),
                            Name = reader.GetString(1),
                            Active = reader.GetBoolean(2)
                        };
                        result.Add(dto);
                    }
                }
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
