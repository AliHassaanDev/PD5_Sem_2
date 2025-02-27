using Problem_1.BL;
using Problem_1.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.UI
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            Console.Write("Enter Degree Name: ");
            string degreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            float degreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            int seats = int.Parse(Console.ReadLine());
            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.Write("Enter How many Subjects to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Subject s = SubjectUI.takeInputForSubject();
                if (degProg.AddSubject(s))
                {
                    if (!SubjectDL.subjectList.Contains(s))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeIntoFile("H:\\Semester 2\\OOPS\\PD5\\Problem_1\\Subject.txt", s);
                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added. 20 credit hour limit exceeded");
                    x--;
                }
            }
            return degProg;
        }

        public static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
    }
}
