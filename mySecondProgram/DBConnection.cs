using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;   // sql data base 

namespace mySecondProgram
{

    //private static final String URL = "jdbc:mysql://127.0.0.1:3306/communication?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC\r\n";
	//private static final String DRIVER = "com.mysql.cj.jdbc.Driver";
	//private static final String PASSWORD = "MySuperPassword";
	//private static final String USERNAME = "root";
	//private static Connection connection = null;



    class DBConnection
    {


        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        private void initialize() {
            server = "localhost";
            //database = "connect csharp to mysql";
            database = "Local instance MySQL80";
            //uid = "username";
            uid = "root";
            password = "MySuperPassword";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }




    }
}
