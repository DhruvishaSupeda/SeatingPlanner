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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class SortedStudentWindow : Window
    {
        public SortedStudentWindow(List<Student> list)
        {
            InitializeComponent();

            int length = list.Count();
            //Assuming 3 rows for now
            decimal temp = (length/2) / 3;
            Console.WriteLine("Length" + length);
            int rows = Decimal.ToInt32(Math.Ceiling(temp));
            if (rows==0)
            {
                rows = 1;
            }
            Console.WriteLine(rows);
            Console.WriteLine("Hello thing");

            var newlist = new List<List<Student>>();

            for (int i = 0; i < list.Count; i += 2)
            {
                newlist.Add(list.GetRange(i, Math.Min(2, list.Count - i)));
            }
            Console.WriteLine(newlist[0].First().forename);
            Console.WriteLine(newlist[1].Last().forename);

            makeLabels(newlist);
        }

        private void makeLabels(List<List<Student>> newlist)
        {
            /*POinter
             * One to divide by 3 so knows when to go to new line
             * One to go to next pair
             * One to go down for the second in the pair
             */
            int left = 131; //+ 85 to top1 to get below, add 212 to get to next one along to the right
            int leftCounter = 1;
            bool isTop = true;
            int top1 = 78;
            int top2 = 104;
            int newleft; int newtop;
            foreach (List<Student> s in newlist)
            {
                //makes the new left
                switch (leftCounter)
                {
                    case 1:
                        newleft = left;
                        break;
                    case 2:
                        newleft = left + 212;
                        break;
                    default:
                        newleft = left + 414;
                        break;
                }

                //now doing the first one
                System.Windows.Forms.Label sLabel = new System.Windows.Forms.Label();
                sLabel.Text = s.First().forename + " " + s.First().surname;
                sLabel.Margin = new Padding(13, 13, 0, 0);
                //second student


                //Changes left counter so you go the next place along or new line
                if (leftCounter == 3)
                {
                    leftCounter = 1;
                    top1 = top1 + 85;
                    top2 = top2 + 85;
                }
                else
                {
                    leftCounter += 1;
                }
            }
        }
    }
}
