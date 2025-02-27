using Problem_1.BL;
using Problem_1.DL;
using Problem_1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "H:\\Semester 2\\OOPS\\PD5\\Problem_1\\Subject.txt";
            string degreePath = "H:\\Semester 2\\OOPS\\PD5\\Problem_1\\DegreeProgram.txt";
            string studentPath = "H:\\Semester 2\\OOPS\\PD5\\Problem_1\\Student.txt";


            SubjectDL.readFromFile(subjectPath);

            DegreeProgramDL.readFromFile(degreePath);

            StudentDL.readFromFile(studentPath);
                

            int option;
            do
            {
                option = MenuUI.Menu();
                MenuUI.clearScreen();
                switch (option)
                {
                    case 1:
                        if (DegreeProgramDL.programList.Count > 0)
                        {
                            Student su = StudentUI.takeInputForStudent();
                            StudentDL.addIntoStudentList(su);
                            StudentDL.storeIntoFile(studentPath, su);
                        }
                        break;
                    case 2:
                        DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                        DegreeProgramDL.addIntoDegreeList(d);
                        DegreeProgramDL.storeIntoFile(degreePath, d);
                        break;
                    case 3:
                        List<Student> sortedStudentList = StudentDL.sortStudentsByMerit();
                        StudentDL.giveAdmission(sortedStudentList);
                        StudentUI.printStudents();
                        break;
                    case 4:
                        StudentUI.viewRegisteredStudents();
                        break;
                    case 5:
                        Console.Write("Enter Degree Name: ");
                        string degName = Console.ReadLine();
                        StudentUI.viewStudentInDegree(degName);
                        break;
                    case 6:
                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();
                        Student s = StudentDL.StudentPresent(name);
                        if (s != null)
                        {
                            SubjectUI.viewSubjects(s);
                            SubjectUI.registerSubjects(s);
                        }
                        break;
                    case 7:
                        StudentUI.calculateFeeForAll();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                MenuUI.clearScreen();
            } while (option != 8);
        }
    }
}