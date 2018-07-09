using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MemberLibrary
{
    public class MemberDAO
    {
        private SqlConnection conn;
        private SqlDataAdapter dAdapter;
        private SqlDataReader dReader;
        private SqlCommand cmd;
        private string cmdLine;
        private readonly string DATABASENAME = "TouchCinemaDB";

        public MemberDAO()
        {

        }

        private void CloseConnect()
        {
            try
            {
                if (conn != null || conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                cmdLine = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings[DATABASENAME].ConnectionString;
        }

        private void SetUpConnect(string commandLine)
        {
            conn = new SqlConnection(GetConnection());
            cmdLine = commandLine;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public MemberDTO CheckLoginMember(string username, string password)
        {
            MemberDTO member = null;
            try
            {
                SetUpConnect("Select firstName, lastName, phone, email, birthDate, avatar " +
                                "From Member " +
                                "Where username = @Username AND password = @Password AND isActive=@isActive");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@isActive", true);
                dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    member = new MemberDTO
                    {
                        Username = username,
                        Password = password,
                        FirstName = dReader.GetString(0),
                        LastName = dReader.GetString(1),
                        PhoneNum = dReader.GetString(2),
                        Email = dReader.GetString(3),
                        Birthdate = dReader.GetDateTime(4),
                        ImageLink = dReader.GetString(5),
                        IsActive = true,
                    };
                }
            }
            catch (Exception)
            {
                member = null;
            }
            finally
            {
                CloseConnect();
            }
            return member;
        }

        public int CheckPointMember(string Username)
        {
            int point = 0;
            try
            {
                SetUpConnect("Select point " +
                            "From Point " +
                            "Where username = @Username");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", Username);
                dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    point = dReader.GetInt32(0);
                }
            }
            finally
            {
                CloseConnect();
            }
            return point;
        }

        private bool UpdatePointMember(string Username, int point)
        {
            bool checker = false;
            try
            {
                SetUpConnect("Update Point " +
                            "Set point = @Point " +
                            "Where username = @Username");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Point", point);
                cmd.Parameters.AddWithValue("@Username", Username);
                checker = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                point = 0;
            }
            finally
            {
                CloseConnect();
            }
            return checker;
        }

        public bool UpdateProfileMember(MemberDTO dto)
        {
            bool checker = false;
            try
            {
                SetUpConnect("Update Member " +
                            "Set password = @Password, firstName = @First, lastName = @Last, phone = @Phone," +
                                " email = @Email, birthDate = @Birth, avatar = @Avatar, isActive = @IsActive" +
                            "Where username = @Username");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Password", dto.Password);
                cmd.Parameters.AddWithValue("@First", dto.FirstName);
                cmd.Parameters.AddWithValue("@Last", dto.LastName);
                cmd.Parameters.AddWithValue("@Phone", dto.PhoneNum);
                cmd.Parameters.AddWithValue("@Email", dto.Email);
                cmd.Parameters.AddWithValue("@Birth", dto.Birthdate);
                cmd.Parameters.AddWithValue("@Avatar", dto.ImageLink);
                cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);
                cmd.Parameters.AddWithValue("@Username", dto.Username);
                checker = cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {
                checker = false;
            }
            finally
            {
                CloseConnect();
            }
            return checker;
        }



        public List<MemberDTO> SearchMemberByUsername(string username)
        {
            List<MemberDTO> listMember = new List<MemberDTO>();
            try
            {
                SetUpConnect("Select username, firstName, lastName, phone, email, birthDate, isActive " +
                    "From Member " +
                    "Where username Like @Username");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", "%" + username + "%");
                dReader = cmd.ExecuteReader();
                if (dReader.HasRows)
                {
                    listMember = new List<MemberDTO>();
                    while (dReader.Read())
                    {
                        MemberDTO dto = new MemberDTO
                        {
                            Username = dReader.GetString(0),
                            FirstName = dReader.GetString(1),
                            LastName = dReader.GetString(2),
                            PhoneNum = dReader.GetString(3),
                            Email = dReader.GetString(4),
                            Birthdate = dReader.GetDateTime(5),
                            IsActive = dReader.GetBoolean(6)
                        };
                        listMember.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listMember = null;
            }
            finally
            {
                conn.Close();
            }
            return listMember;
        }


        public bool AddNewMemberAdmin(MemberDTO dto)
        {
            bool checker = false;
            try
            {
                SetUpConnect("Insert Into Member " +
                    "Values(@Username, @Password, @FirstName, @LastName, @Phone, @Email, @BirthDate, @Avatar, @isActive)");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", dto.Username);
                cmd.Parameters.AddWithValue("@Password", dto.Password);
                cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                cmd.Parameters.AddWithValue("@Phone", dto.PhoneNum);
                cmd.Parameters.AddWithValue("@Email", dto.Email);
                cmd.Parameters.AddWithValue("@BirthDate", dto.Birthdate);
                cmd.Parameters.AddWithValue("@Avatar", dto.ImageLink);
                cmd.Parameters.AddWithValue("@isActive", dto.IsActive);
                checker = cmd.ExecuteNonQuery() > 0;
                if (checker)
                {
                    SetUpConnect("Insert into Point Values(@username, @point)");
                    cmd = new SqlCommand(cmdLine, conn);
                    cmd.Parameters.AddWithValue("@username", dto.Username);
                    cmd.Parameters.AddWithValue("@point", 0);
                    checker = cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                CloseConnect();
            }
            return checker;
        }

        public bool UpdateMemberStatus(string username, int status)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(GetConnection());
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Update Member set isActive=@isActive WHERE username=@username";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
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

        public MemberDTO SearchMember(string search)
        {
            MemberDTO output = null;
            SqlConnection conn = new SqlConnection(GetConnection());
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select username, firstName, lastName, phone, email from Member where (username=@search or email=@search or phone=@search) and isActive=@isActive";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", search);
                    cmd.Parameters.AddWithValue("@isActive", true);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            output = new MemberDTO
                            {
                                Username = reader.GetString(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                PhoneNum = reader.GetString(3),
                                Email = reader.GetString(4),
                            };
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return output;
        }

        public bool IsUsernameExist(string username)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(GetConnection());
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string sql = "Select username from Member where username=@search";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
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

        public List<MemberDTO> GetMemberList()
        {
            List<MemberDTO> listMember = null;
            SqlConnection conn = new SqlConnection(GetConnection());
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string sql = "Select username, firstName, lastName, phone, email,birthDate, isActive FROM Member";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    listMember = new List<MemberDTO>();
                    while (reader.Read())
                    {
                        MemberDTO dto = new MemberDTO
                        {
                            Username = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNum = reader.GetString(3),
                            Email = reader.GetString(4),
                            Birthdate = reader.GetDateTime(5),
                            IsActive = reader.GetBoolean(6)
                        };
                        listMember.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listMember = null;
            }
            finally
            {
                conn.Close();
            }
            return listMember;
        }

    }
}
