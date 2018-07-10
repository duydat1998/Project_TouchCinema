using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace UltilitiesLibrary
{
    public class DatabaseConnection
    {
        public DatabaseConnection()
        {

        }

        //Nhớ xóa MayHieuBT để về lại ConnectionString cũ
        //ai dùng máy HieuBTSE62797 nhớ để thêm MayHieuBT
        //Trước khi push nhớ comment all cho ai cần làm
        public string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;
            ///return ConfigurationManager.ConnectionStrings["TouchCinemaDBMayHieuBT"].ConnectionString;
            //private SqlConnection checkConn;
            //strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDBMayHieuBT"].ConnectionString;
            //try
            //{
            //    checkConn = new SqlConnection(strConnection);
            //    checkConn.Open();
            //}
            //catch(Exception)
            //{
            //    strConnection = ConfigurationManager.ConnectionStrings["TouchCinemaDBMayHieuBT"].ConnectionString;
            //}
            //finally
            //{
            //    if(checkConn.State != ConnectionState.Closed)
            //    {
            //        checkConn.Close();
            //    }
            //}
        }
    }
}
