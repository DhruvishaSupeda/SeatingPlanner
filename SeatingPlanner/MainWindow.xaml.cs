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
    }
}
