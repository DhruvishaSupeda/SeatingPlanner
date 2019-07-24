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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class SortStudentWindow : Window { 

        DBConnect db = new DBConnect();
        
        public SortStudentWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            //Just sorting them into ascending grade for now
            Alphabetical();
        }

        private void AscGrade()
        {
            List<Student> list = db.convertStudents();
            int length = list.Count;
            List<Student> SortedList = list.OrderBy(o => o.average_grade).ToList();
            for (int i = 0; i < length; i++)
            {
                Console.Write(SortedList[i].forename);
                Console.WriteLine(" " + SortedList[i].average_grade);
            }
        }

        private void DescGrade()
        {
            List<Student> list = db.convertStudents();
            int length = list.Count;
            List<Student> SortedList = list.OrderByDescending(o => o.average_grade).ToList();
            for (int i = 0; i < length; i++)
            {
                Console.Write(SortedList[i].forename);
                Console.WriteLine(" " + SortedList[i].average_grade);
            }
        }

        private void Alphabetical()
        {
            List<Student> list = db.convertStudents();
            int length = list.Count;
            List<Student> SortedList = list.OrderBy(o => o.surname).ToList();
            for (int i = 0; i < length; i++)
            {
                Console.Write(SortedList[i].surname);
                //Console.WriteLine(" " + SortedList[i].average_grade);
            }
        }

        private void Gender()
        {
            
        }


    }
}
