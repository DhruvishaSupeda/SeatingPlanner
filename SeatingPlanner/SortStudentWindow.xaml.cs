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
        List<Student> SortedList = new List<Student>();
        
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
            List<Student> SortedList = AscGrade();
            //So put if front, put the front ones first
            //Then take this list, do the same with window
            //Then take that list do the same with door
            //Then case of whichever one they've picked with the remaining list? Idk how to do window and door maybe it'll somehow work out
            //If not graphic, just downwards list and put (window) or (door) or (front) next to them
            new SortedStudentWindow(SortedList).Show();
            this.Close();
        }

        private List<Student> AscGrade()
        {
            List<Student> list = db.convertStudents();
            int length = list.Count;
            List<Student> SortedList = list.OrderBy(o => o.average_grade).ToList();
            return SortedList;
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

        private List<Student> Gender()
        {
            //https://codereview.stackexchange.com/questions/207240/alternating-items-in-a-collection

            List<Student> list = db.convertStudents();

            //Make male list and female list
            List<Student> male = new List<Student>() { };
            List<Student> female = new List<Student>() { };

            male = list.Where(c => c.gender == "Male").ToList();
            for (int i = 0; i < male.Count; i++)
            {
                Console.Write("Thing");
                //Console.WriteLine(" " + SortedList[i].average_grade);
            }
            female = list.Where(c => c.gender == "Female").ToList();

            int length = list.Count;
            int indexMale = 0;
            int indexFemale = 0;

            List<Student> SortedList = new List<Student>();

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 1)
                {
                    if (indexMale < male.Count)
                    {
                        SortedList.Add(male[indexMale]);
                        indexMale++;
                    }
                    else
                    {
                        SortedList.Add(female[indexFemale]);
                        indexFemale++;
                    }
                }
                else
                {
                    if (indexFemale < female.Count)
                    {
                        SortedList.Add(female[indexFemale]);
                        indexFemale++;
                    }
                    else
                    {
                        SortedList.Add(male[indexMale]);
                        indexMale++;
                    }
                }
            }

            Console.WriteLine("UNSORTED");
            for (int i = 0; i < length; i++)
            {
                Console.Write(list[i].gender);
                //Console.WriteLine(" " + SortedList[i].average_grade);
            }

            Console.WriteLine(" ");
            Console.WriteLine("SORTED");
            return SortedList;
        }


    }
}
