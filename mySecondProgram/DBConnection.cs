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

        // todo: check me out 
        // https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL

        public DBConnection() {
            initialize();
        }



        private void initialize() {
        server = "localhost";
            //database = "connect csharp to mysql";
            database = "Local instance MySQL80";
            //uid = "username";
            uid = "root";
            password = "MySuperPassword";
            string connectionString;
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";


            // Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            connectionString = "Server=localhost;Port=3306;Database=http_requests;Uid=root;Pwd=MySuperPassword;";
            //connectionString = "datasource=localhost;port=3306;username=root;password=MySuperPassword";

            connection = new MySqlConnection(connectionString);

        }
        //open connection to database

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator " + ex.Message);
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again " + ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Cannot close db connection: " + e.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string str = "Insert into http_requests_history (end_point,method,header,body)values(@endPoint,@method,@header,@body)";
            if (this.OpenConnection() == true) {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = str;
                cmd.Parameters.AddWithValue("@endPoint", "/EndPoint");
                cmd.Parameters.AddWithValue("@method", "Get");
                cmd.Parameters.AddWithValue("@header", "Headers.");
                cmd.Parameters.AddWithValue("@body", "body");
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

                this.CloseConnection();
     
            }

        }
        /*
        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List<string>[] Select()
        {
        }

        //Count statement
        public int Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

    */

    }
}
