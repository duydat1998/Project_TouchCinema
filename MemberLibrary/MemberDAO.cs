using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MovieLibrary;
using ScheduleLibrary;

namespace MemberLibrary
{
    class MemberDAO
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
                if(conn!= null || conn.State != ConnectionState.Closed)
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
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public MemberDTO CheckLoginMember(string Username, string Password)
        {
            MemberDTO member = null;
            try
            {
                SetUpConnect("Select username, password, firstName, lastName, phone, email, birthDate, avatar, isActive " +
                                "From Member " +
                                "Where username = @Username AND password = @Password;");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                dReader = cmd.ExecuteReader();
                if (dReader.Read())
                {
                    member = new MemberDTO
                    {
                        Username = dReader.GetString(0),
                        Password = dReader.GetString(1),
                        FirstName = dReader.GetString(2),
                        LastName = dReader.GetString(3),
                        PhoneNum = dReader.GetString(4),
                        Email = dReader.GetString(5),
                        Birthdate = dReader.GetDateTime(6),
                        ImageLink = dReader.GetString(7),
                        isActive = dReader.GetBoolean(8),
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
            catch (Exception)
            {
                point = 0;
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
                cmd.Parameters.AddWithValue("@IsActive", dto.isActive);
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

        public List<MovieDTO> SearchListMoiveMemberGuest(string movieName)
        {
            List<MovieDTO> listMovive = null;
            try
            {
                SetUpConnect("Select movieTitle, length, rating, startDate, poster, linkTrailer, producer, year " +
                            "From Movie " +
                            "Where movieTitle Like  @MovieName ");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@MovieName", "'%'" + movieName + "'%'");
                dReader = cmd.ExecuteReader();
                if (dReader.HasRows)
                {
                    listMovive = new List<MovieDTO>();
                    while (dReader.Read())
                    {
                        MovieDTO dto = new MovieDTO
                        {
                            MovieTitle = dReader.GetString(0),
                            Length = dReader.GetInt32(1),
                            Rating = dReader.GetInt32(2),
                            StartDate = dReader.GetDateTime(3),
                            Poster = dReader.GetString(4),
                            LinkTrailer = dReader.GetString(5),
                            Producer = dReader.GetString(6),
                            Year = dReader.GetInt32(7),
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
                CloseConnect();
            }
            return listMovive;
        }
       
        public List<MemberDTO> SearchMemberByUsername(string username)
        {
            List<MemberDTO> listMember = null;
            try
            {
                SetUpConnect("Select username, firstName, lastName, phone, email, birthDate, isActive " +
                    "From Member " +
                    "Where username Like @Username");
                cmd = new SqlCommand(cmdLine, conn);
                cmd.Parameters.AddWithValue("@Username", "'%'" + username + "'%'");
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
                            isActive= dReader.GetBoolean(6)
                        };
                        listMember.Add(dto);
                    }
                }
            }
            catch (Exception)
            {
                listMember = null;                
            }
            return listMember;
        }

        public bool RegisterAccountGuest(MemberDTO dto)
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
                cmd.Parameters.AddWithValue("@isActive", dto.isActive);
                checker = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                checker = false;
            }
            return checker;
        }

        public bool RemoveMember(string username)
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
                    cmd.Parameters.AddWithValue("@isActive", false);
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
    }
}
