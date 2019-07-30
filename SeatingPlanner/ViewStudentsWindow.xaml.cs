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
        DBConnect db = new DBConnect();

        public ViewStudentsWindow()
        {
            InitializeComponent();
            //basically go through with the nested for loop, for each list go to item i, then put it all into array of students or whatever
            //then show that on the table somehow
            //seems the easiest way idk

            //gets array of lists for everything (which is db.convertStudents())
            List<Student> list = db.convertStudents();
            dtgStudents.ItemsSource = list;
        }
    }
}
