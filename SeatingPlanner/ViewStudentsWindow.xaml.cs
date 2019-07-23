using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

            //gets array of lists for everything (which is db.Select())
            //gets number of rows/records
            int length = db.SelectID().Count;
            //Gets all of the rows and the data in the rows
            List<string>[] allRows = db.SelectByRow();
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
                Student student = new Student(fore, sur, gend, doobb, windooww, doorr, froont);
                list.Add(student);
            }
            dtgStudents.ItemsSource = list;
        }
    }
}
