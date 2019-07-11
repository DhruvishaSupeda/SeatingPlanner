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
        public AddStudentWindow()
        {
            InitializeComponent();
            dprDOB.SelectedDate = new DateTime(2006, 1, 1);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string forename = txtForename.Text;
            string surname = txtSurname.Text;
            string dob = (dprDOB.SelectedDate.Value).ToString("yyyy-MM-dd");

        }
    }
}
