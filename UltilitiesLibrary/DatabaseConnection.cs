using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace UltilitiesLibrary
{
    public class DatabaseConnection
    {
        public DatabaseConnection()
        {

        }

        public string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["TouchCinemaDB"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["TouchCinemaDBMayHieuBT"].ConnectionString;
        }
        
    }
}
