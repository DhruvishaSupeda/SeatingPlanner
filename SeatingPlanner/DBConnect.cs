using System;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace SeatingPlanner
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "seating_planner";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
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
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string forename, string surname, string gender, string dob, int window, int door,int front, int grade)
        {
            //string query = "INSERT INTO `seating_planner`.`student` (`forename`,`surname`,`gender`,`dob`,`window`,`door`,`front`) " +
                //"VALUES ('Bye','Bye','Female','1999-02-15',0,1,0)";

            string query = "INSERT INTO `seating_planner`.`student` (`forename`,`surname`,`gender`,`dob`,`window`,`door`,`front`,`average_grade`) " +
                "VALUES ('" + forename + "','" + surname + "','" + gender + "','" + dob + "'," + window + "," + door + "," + front + "," + grade + ")";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE student SET forename='Joe' WHERE forename='John'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM student WHERE forename='Joe'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        //Select statement
        public List<string>[] SelectByRow()
        {
            string query = "SELECT * FROM student";

            int size = this.SelectID().Count;

            List<string>[] list = new List<string>[size];

            for (int i = 0; i < size; i++)
            {
                list[i] = new List<string>();
            }

            //Open connection
            if (this.OpenConnection() == true)
            {
                Console.WriteLine("Opened a thing");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                int counter = 0;
                while (dataReader.Read())
                {
                    list[counter].Add(dataReader["forename"] + "");
                    list[counter].Add(dataReader["surname"] + "");
                    list[counter].Add(dataReader["gender"] + "");
                    list[counter].Add(dataReader["dob"] + "");
                    list[counter].Add(dataReader["window"] + "");
                    list[counter].Add(dataReader["door"] + "");
                    list[counter].Add(dataReader["front"] + "");
                    list[counter].Add(dataReader["average_grade"] + "");
                    counter += 1;
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        public List<string>[] Select()
        {
            string query = "SELECT * FROM student";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idstudent"] + "");
                    list[1].Add(dataReader["forename"] + "");
                    list[2].Add(dataReader["surname"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public List<string> SelectID()
        {
            string query = "SELECT idstudent FROM student";

            //Create a list to store the result
            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["idstudent"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Gets list of Student objects with all the students
        public List<Student> convertStudents()
        {
            //gets number of rows/records
            int length = SelectID().Count;
            //Gets all of the rows and the data in the rows
            List<string>[] allRows = SelectByRow();
            List<Student> list = new List<Student>();
            //Makes student for each row then adds to list of students
            for (int i = 0; i < length; i++)
            {
                List<string> selected = allRows[i];
                string fore = selected[0];
                string sur = selected[1];
                string gend = selected[2];
                int index = selected[3].IndexOf(' ');
                string doobb = selected[3].Substring(0, index);
                int windooww = int.Parse(selected[4]);
                int doorr = int.Parse(selected[5]);
                int froont = int.Parse(selected[6]);
                int avg = int.Parse(selected[7]);
                Student student = new Student(fore, sur, gend, doobb, windooww, doorr, froont, avg);
                list.Add(student);
            }
            return list;
        }

        public void Import(string path)
        {
            string query = "LOAD DATA LOCAL INFILE '" + path + "' REPLACE INTO TABLE student FIELDS TERMINATED BY ',' lines terminated by '\n';";

            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Count statement
        //public int Count()
        //{
        // }

        //Backup
        // public void Backup()
        // {
        // }

        //Restore
        //  public void Restore()
        // {
        //  }
    }
}
