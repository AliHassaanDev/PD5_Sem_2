using Problem_1.BL;
using Problem_1.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.UI
{
    internal class StudentUI
    {
        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");
                }
            }
        }

        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null && degName == s.regDegree.degreeName)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }

        public static Student takeInputForStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            double fscMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            double ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs:");
            DegreeProgramUI.viewDegreePrograms();
            Console.WriteLine("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            for (int x = 0; x < Count; x++)
            {
                Console.WriteLine("Enter Degree Name: ");
                string degName = Console.ReadLine();
                DegreeProgram d = DegreeProgramDL.isDegreeExists(degName);
                if (d != null)
                {
                    preferences.Add(d);
                }
                else
                {
                    Console.WriteLine("Invalid Degree Program Name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }

        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.calculateFee() + " fees");
                }
            }
        }
    }
}
