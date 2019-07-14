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
            DataGridColumn column = new DataGridTextColumn();
            //column.DataPropertyName = "Name";
            column.Header = "Forename";
            dtgStudents.Columns.Add(column);


            //gets array of lists for everything (which is db.Select())
            int length = db.Select().Length;
            for (int i = 0; i < length; i++)
            {
                List<string> selected = db.Select()[i];
                foreach (string item in selected)
                {
                    Console.Write(item);
                    Console.WriteLine();
                }
            }

            List<string> fore = db.Select()[0];
            int le = fore.Count();
            for (int j = 0; j < le; j++)
            {

            }
        }
    }
}
