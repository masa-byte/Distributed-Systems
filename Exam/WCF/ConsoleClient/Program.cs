using ConsoleClient.EdnevnikServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var proxy = new EdnevnikClient(new InstanceContext(new EdnevnikCallback()));

            Console.WriteLine("Professor or Parent?");
            string role = Console.ReadLine();

            if (role.ToLower() == "1")
            {
                StartProffesor(proxy);
            }
            else if (role.ToLower() == "2")
            {
                StartParent(proxy);
            }
            else
            {
                Console.WriteLine("Invalid role");
            }
        }

        private static void StartParent(EdnevnikClient proxy)
        {
            Console.WriteLine("Enter parent id:");
            int parentId = int.Parse(Console.ReadLine());

            proxy.RegisterParent(new Parent { Id = parentId });

            while (true)
            {
                Console.WriteLine("1. Add child\n2. Get child grades");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    var students = proxy.GetAllStudents();

                    foreach (var student in students)
                    {
                        Console.WriteLine($"Student id: {student.Id}");
                    }

                    Console.WriteLine("Enter student id:");
                    int studentId = int.Parse(Console.ReadLine());

                    proxy.AddChild(new Student { Id = studentId });
                }
                else if (choice == "2")
                {
                    var myChildren = proxy.GetParentChildren();

                    foreach (var child in myChildren)
                    {
                        Console.WriteLine($"Child id: {child.Id}");
                    }

                    Console.WriteLine("Enter student id:");
                    int studentId = int.Parse(Console.ReadLine());

                    var coursesGrades = proxy.GetChildsGrades(new Student { Id = studentId });

                    foreach (var course in coursesGrades)
                    {
                        foreach (var grade in course.Value)
                        {
                            Console.WriteLine($"Course: {course.Key} grade: {grade}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }

        private static void StartProffesor(EdnevnikClient proxy)
        {
            Console.WriteLine("Enter proffesor id:");
            int proffesorId = int.Parse(Console.ReadLine());

            proxy.RegisterProfessor(new Professor { Id = proffesorId, Course = "Biology" });

            while (true)
            {
                Console.WriteLine("1. Add student\n2. Grade student");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter student id:");
                    int studentId = int.Parse(Console.ReadLine());

                    proxy.AddStudent(new Student { Id = studentId });
                }
                else if (choice == "2")
                {
                    var myStudents = proxy.GetProfessorStudents();

                    foreach (var student in myStudents)
                    {
                        Console.WriteLine($"Student id: {student.Id}");
                    }

                    Console.WriteLine("Enter student id:");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter grade:");
                    int grade = int.Parse(Console.ReadLine());

                    proxy.GradeStudent(new Student { Id = studentId }, grade);
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }


        public class EdnevnikCallback : IEdnevnikCallback
        {
            public void NotifyParent(string courseName, int grade)
            {
                Console.WriteLine($"Course: {courseName}; Grade {grade}");
            }
        }
    }
}
