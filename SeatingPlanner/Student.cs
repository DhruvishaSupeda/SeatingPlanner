using System;

namespace SeatingPlanner
{
    internal class Student
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public int window { get; set; }
        public int door { get; set; }
        public int front { get; set; }
        public int average_grade { get; set; }

        public Student(string f, string s, string g, string d, int w, int doo, int fro, int avg)
        {
            forename = f;
            surname = s;
            gender = g;
            dob = d;
            window = w;
            door = doo;
            front = fro;
            average_grade = avg;
        }
    }
}