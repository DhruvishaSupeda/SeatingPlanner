using System;

namespace SeatingPlanner
{
    internal class Student
    {
        public string forename;
        public string surname;
        public string gender;
        public string dob;
        public int window;
        public int door;
        public int front;

        public Student(string f, string s, string g, string d, int w, int doo, int fro)
        {
            forename = f;
            surname = s;
            gender = g;
            dob = d;
            window = w;
            door = doo;
            front = fro;
        }
    }
}
