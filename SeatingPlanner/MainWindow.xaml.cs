using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeatingPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnect db = new DBConnect();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            new SortStudentWindow().Show();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddStudentWindow().Show();
            this.Close();
        }

        private void BtnDB_Click(object sender, RoutedEventArgs e)
        {
           // db.Insert();
            Console.WriteLine("Done a thing");

            List<string>[] hello = db.Select();
            int length = hello.Length;
            Console.WriteLine(length + " is the length");

            for (int i = 0; i < length; i++)
            {
                List<string> selected = hello[i];
                foreach (string item in selected)
                {
                    Console.Write(item);
                    Console.WriteLine();
                }
            }
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            new ViewStudentsWindow().Show();
            this.Close();
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.ShowDialog();
            //openfiledialog1.Filter = "allfiles|*.xlsx";
            txtFile.Text = openfiledialog1.FileName;
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult confirmation = System.Windows.MessageBox.Show("This will overwrite the current class of students.", "Warning", MessageBoxButton.OKCancel);
            if (confirmation == MessageBoxResult.OK)
            {
                string path = txtFile.Text;
                Console.WriteLine("THIS DO A THING");

                string ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties = Excel 8.0";
                //string ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";

                DataTable Data = new DataTable();

                using (OleDbConnection conn = new OleDbConnection(ConnString))
                {
                    conn.Open();
                    //Get data fro sheet one
                    OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", conn);
                    DataSet excelDataSet = new DataSet();
                    //Put data into dataset
                    objDA.Fill(excelDataSet);
                    //Only one table in dataset so get that table
                    Data = excelDataSet.Tables[0];
                }

                db.ClearTable();

                foreach (DataRow row in Data.Rows)
                {
                    /*foreach (DataColumn column in Data.Columns)
                    {
                        Console.WriteLine(row[column]);
                    }*/
                    //For each row gets the data
                    string forename = row["forename"].ToString();
                    string surname = row["surname"].ToString();
                    string gender = row["gender"].ToString();
                    string dob = row["dob"].ToString();
                    int window = int.Parse(row["window"].ToString());
                    int door = int.Parse(row["door"].ToString());
                    int front = int.Parse(row["front"].ToString());
                    int grade = int.Parse(row["average_grade"].ToString());
                    //Inserts into the database
                    db.Insert(forename, surname, gender, dob, window, door, front, grade);
                }
            }

        }
    }
}
