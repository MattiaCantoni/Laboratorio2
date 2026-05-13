using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HelloLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Student> students = Student.GetStudents();

            // 4.
            //1.
            Console.WriteLine("4.");
            Console.WriteLine("-------------------------");
            List<Student> higherThan70 = students.Where(x => x.Grade >= 70).ToList();

            foreach (Student student in higherThan70)
            {
                Console.WriteLine(student.Grade);
            }
            Console.WriteLine("-------------------------");
            //2.
            List<Student> branchInformatica = students.Where(x => x.Branch == "Informatica").ToList();

            foreach (Student student in branchInformatica)
            {
                Console.WriteLine(student.Branch);
            }
            Console.WriteLine("-------------------------");
            //3.
            bool grade100 = students.Any(x => x.Grade == 100);
            Console.WriteLine(grade100);
            Console.WriteLine("-------------------------");
            //4.
            bool allAbove40 = students.All(x => x.Grade == 40);
            Console.WriteLine(allAbove40);
            Console.WriteLine("-------------------------");
            //5.
            Student firstTelecomunicazioni = students.FirstOrDefault(x => x.Branch == "Telecomunicazioni");
            Console.WriteLine(firstTelecomunicazioni.Branch);
            Console.WriteLine("-------------------------");
            //6.
            Student ID1001 = students.SingleOrDefault(x => x.ID == 1001);
            Console.WriteLine(ID1001.ID);
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");
            Console.WriteLine("5.");
            Console.WriteLine("-------------------------");
            //7.
            List<string> nomi = students.Select(x => x.Name).ToList();
            foreach (string student in nomi)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("-------------------------");
            //8.
            List<string> nomiUpper = students.Select(x => x.Name.ToUpper()).ToList();
            foreach (string student in nomiUpper)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("-------------------------");
            //9.
            var oggAnonimi = students
                .Select(x => new
                {
                    x.Name, 
                    x.Grade
                }).ToList();
            foreach (var student in oggAnonimi)
            {
                Console.WriteLine(student.Name + ";" + student.Grade);
            }


        }
    }
}
