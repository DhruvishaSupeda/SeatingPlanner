using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SeatingPlanner
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        readonly DBConnect db = new DBConnect();

        public AddStudentWindow()
        {
            InitializeComponent();
            dprDOB.SelectedDate = new DateTime(2006, 1, 1);
            rdbFemale.IsChecked = true;
            for (int i = 1; i <= 100; i++)
            {
                lbxGrade.Items.Add(i);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string forename = txtForename.Text;
            string surname = txtSurname.Text;
            string dob = (dprDOB.SelectedDate.Value).ToString("yyyy-MM-dd");
            string gender = "";
            int window = 0;
            int door = 0;
            int front = 0;
            if (rdbFemale.IsChecked == true)
            {
                gender = "Female";
            }
            else
                gender = "Male";

            if (chbxWindow.IsChecked == true)
            {
                window = 1;
            }
            if (chbxDoor.IsChecked == true)
            {
                door = 1;
            }
            if (chbxFront.IsChecked == true)
            {
                front = 1;
            }
            int grade = int.Parse(lbxGrade.SelectedItem.ToString());

            db.Insert(forename, surname, gender, dob, window, door, front, grade);
        }
    }
}
