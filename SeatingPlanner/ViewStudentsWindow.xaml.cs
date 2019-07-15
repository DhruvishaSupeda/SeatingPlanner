using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SeatingPlanner
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewStudentsWindow : Window
    {
        private BindingSource bindingSource1 = new BindingSource();
        DBConnect db = new DBConnect();

        public ViewStudentsWindow()
        {
            InitializeComponent();
            //basically go through with the nested for loop, for each list go to item i, then put it all into array of students or whatever
            //then show that on the table somehow
            //seems the easiest way idk

            // Initialize and add a text box column.
            addColumns();
            DataGridColumn forename = new DataGridTextColumn();
            forename.Header = "Forename";
            DataGridColumn surname = new DataGridTextColumn();
            surname.Header = "Surname";
            DataGridColumn gender = new DataGridTextColumn();
            gender.Header = "Gender";
            DataGridColumn dob = new DataGridTextColumn();
            dob.Header = "Date of Birth";
            DataGridColumn window = new DataGridTextColumn();
            window.Header = "Near Window (1/0)";
            DataGridColumn door = new DataGridTextColumn();
            door.Header = "Near Door (1/0)";
            DataGridColumn front = new DataGridTextColumn();
            front.Header = "Near the Front (1/0)";
            dtgStudents.Columns.Add(forename);
            dtgStudents.Columns.Add(surname);
            dtgStudents.Columns.Add(gender);
            dtgStudents.Columns.Add(dob);
            dtgStudents.Columns.Add(window);
            dtgStudents.Columns.Add(door);
            dtgStudents.Columns.Add(front);

            //gets array of lists for everything (which is db.Select())
            int length = db.SelectID().Count;
            List<string>[] allRows = db.SelectByRow();
            for (int i = 0; i < length; i++)
            {
                List<string> selected = allRows[i];
                foreach (string item in selected)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
