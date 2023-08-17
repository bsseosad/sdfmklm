using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PREINSPECTION
{
    internal static class ConnectDB
    {   
        static public MySqlConnection connectDB()
        {
            MySqlConnection sqlConnection_TEAMDB = new MySqlConnection("SERVER = 34.64.95.8; DATABASE = dbQA; UID = bs; PWD = 939313aa!!");
            try
            {
                sqlConnection_TEAMDB.Open();
                return sqlConnection_TEAMDB;
            }
            catch (Exception e)
            {
                Log.writeLog(e.ToString());
                return null;
            }

        }   
    }
}
