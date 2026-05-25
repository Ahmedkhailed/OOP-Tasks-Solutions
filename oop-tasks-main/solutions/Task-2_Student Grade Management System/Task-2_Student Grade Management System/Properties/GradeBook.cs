using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Student_Grade_Management_System.Properties
{
    public class GradeBook
    {
        public string ClassName { get; private set; }
        public List<Student> Students { get; private set; }

        public GradeBook(string className )
        {
            this.ClassName = className;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                return;

            if (student.IsRegisteredClass)
            {
                Console.WriteLine($"Sorry {student.Name} is Registered in {student.NameOfClassRegistered}");
                return;
            }

            Students.Add(student);
        }

        public void RemoveStudent(string studentID)
        {
            Student student = FindStudent(studentID);

            if (student == null)
            {
                Console.WriteLine($"Sorry not found student by id {studentID} registered here");
                return;
            }

            Students.Remove(student);
        }

        public Student FindStudent(string studentID) => Students.Find(x => x.studentId.Equals(studentID));

        public double GetClassAverage() => Students.Average(x => x.calculateAverage());

        public List<Student> GetTopStudents(int count)
        {
            if (Students == null)
                return null;

            return Students.OrderByDescending(x => x.calculateAverage()).Take(count).ToList();
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine($"=== {ClassName} - All Students ===");
            foreach (var item in Students)
            {
                Console.WriteLine($"{item.studentId} - {item.Name}: {Math.Round(item.calculateAverage(), 2)} ({item.getLetterGrade()})");
            }
            Console.WriteLine("\n");
        }

        public List<Student> GetStudentsByLetterGrade(string letterGrade) => Students.FindAll(x => x.getLetterGrade().Equals(letterGrade));

        public void GenerateAndSaveReport()
        {
            string reportContent = "";
            foreach (var item in Students)
            {
                reportContent += $@"

==================================================
                 STUDENT GRADE REPORT
==================================================
Student ID   : {item.studentId}
Student Name : {item.Name}
Issue Date   : {DateTime.Now}
--------------------------------------------------
SUBJECT DETAILS:
{item.GetSubjectInfo()}
--------------------------------------------------
FINAL PERFORMANCE SUMMARY:
--------------------------------------------------
Attendance Percentage : {item.CalculateAttendancePercentage()}%
Final Average         : {Math.Round(item.calculateAverage(),2)}
Final Letter Grade    : {item.getLetterGrade()}
==================================================

";
            }

            try
            {
                string FileName = $"C:\\Report_{ClassName}.txt";
                File.WriteAllText(FileName, reportContent);
                Console.WriteLine("Report Generated and save successfully");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failed to save the report: {ex.Message}");
            }
        }

    }
}
