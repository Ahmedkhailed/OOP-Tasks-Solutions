using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Student_Grade_Management_System.Properties;

namespace Task_2_Student_Grade_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a gradebook
            GradeBook gradeBook = new GradeBook("Computer Science 101");

            // Create students
            Student student1 = new Student("Alice Johnson", "alice@school.com");
            Student student2 = new Student("Bob Smith", "bob@school.com");
            Student student3 = new Student("Charlie Brown", "charlie@school.com");

            // Add grades for students
            student1.addGrade("Math", 92.0);
            student1.addGrade("English", 88.0);
            student1.addGrade("Science", 82.0);

            student2.addGrade("Math", 78.0);
            student2.addGrade("English", 85.0);
            student2.addGrade("Science", 80.0);

            student3.addGrade("Math", 50.0);
            student3.addGrade("English", 30.0);
            student3.addGrade("Science", 59.0);

            // Add students to gradebook
            gradeBook.AddStudent(student1);
            gradeBook.AddStudent(student2);
            gradeBook.AddStudent(student3);

            // Display all students
            gradeBook.DisplayAllStudents();

            // Get class average
            Console.WriteLine("\nClass Average: " + Math.Round(gradeBook.GetClassAverage(), 2));

            // Get top students
            List<Student> topStudents = gradeBook.GetTopStudents(2);
            Console.WriteLine("\nTop 2 Students:");
            foreach (var student in topStudents)
            {
                Console.WriteLine(student.Name + ": " + Math.Round(student.calculateAverage(), 2));

            }

            // Get student info
            Console.WriteLine(student1.getStudentInfo());

            gradeBook.GenerateAndSaveReport();
        }
    }
}
