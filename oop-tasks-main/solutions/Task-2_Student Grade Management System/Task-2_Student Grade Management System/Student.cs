using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Task_2_Student_Grade_Management_System
{
    public class Student
    {
        public string studentId { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Dictionary<string , double> Grades { get; private set; }
        public Dictionary<string, List<bool>> attendanceDict { get; private set; }

        public bool IsRegisteredClass { get; private set; }
        public string NameOfClassRegistered { get; private set; }
        public Student(string name, string email)
        {
            Guid uniqueGuid = Guid.NewGuid();
            studentId = uniqueGuid.ToString();
            this.Name = name;
            this.Email = email;
            Grades = new Dictionary<string, double>();
            this.IsRegisteredClass = false;
            this.NameOfClassRegistered = null;
            attendanceDict = new Dictionary<string, List<bool>>();
        }

        public void AttendToDay(string subject, bool attend)
        {
            if (attendanceDict.TryGetValue(subject, out List<bool> value))
            {
                value.Add(attend);
                attendanceDict[subject] = value;
            }
            else
            {
                attendanceDict[subject] = new List<bool>() { attend };
            }
        }

        public double CalculateAttendancePercentageBySubject(string subject)
        {
            if (!attendanceDict.Any())
                return 100;

            if (!attendanceDict.TryGetValue(subject, out List<bool> subjectDays))
            {
                throw new KeyNotFoundException($"this {subject} not found");
            }

            if (subjectDays.Count <= 0)
                return 100;

            return ((double)subjectDays.Count(x => x) / subjectDays.Count) * 100;
        }

        public double CalculateAttendancePercentage()
        {
            if (!attendanceDict.Any())
                return 100;

            int TotalDays = attendanceDict.Sum(x => x.Value.Count);

            if (TotalDays <= 0)
                return 100;

            int presentDay = attendanceDict.SelectMany(x => x.Value).Count(x => x);

            return ((double)presentDay / TotalDays) * 100;
        }

        private double ReadValueBetween0and90()
        {
            double value;
            do
            {
                Console.Write("Please Enter Value between 0 and 90: ");
                double.TryParse(Console.ReadLine(), out value);
            } while (value > 90 || value < 0);
            return value;
        }

        //Add or update a grade for a subject
        public void addGrade(string subject, double grade)
        {
            if (grade > 90 || grade < 0)
            {
                throw new ArgumentOutOfRangeException($"is grade {grade} out of range please enter grade between 0 and 90");
            }

            Grades[subject] = grade + (CalculateAttendancePercentageBySubject(subject) / 10);
        }

        public double getGrade(string subject)
        {
            if (Grades.TryGetValue(subject, out double value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException($"{subject} not found");
            }
        }

        public double calculateAverage()
        {
            if (!Grades.Any())
                throw new ArgumentNullException("No grades have been entered yet.");

            return Grades.Average(x => x.Value);
        }

        public char getLetterGrade()
        {
            double Average = calculateAverage();
            if (Average > 100 || Average < 0)
                throw new ArgumentOutOfRangeException($"Average: {Average} not valid");

            if (Average >= 90) return 'A';
            if (Average >= 80) return 'B';
            if (Average >= 70) return 'C';
            if (Average >= 60) return 'D';
            return 'F';
        }
        public string getStudentInfo()
        {
            string studentInfo = "\n=== Student Information ===\n";
            studentInfo += $"ID: {studentId}\n";
            studentInfo += $"Name: {Name}\n";
            studentInfo += $"Email: {Email}\n";
            studentInfo += $"Grades:\n";
            foreach (var item in Grades)
            {
                studentInfo += ($"{item.Key}: {Math.Round(item.Value, 2)}\n");
            }
            studentInfo += $"Average: {Math.Round(calculateAverage(), 2)} ({getLetterGrade()})";
            return studentInfo;
        }

        public string GetSubjectInfo()
        {
            string details = "";

            foreach (var item in Grades)
            {
                details += $"- {item.Key, -12}\t:{item.Value}\n";
            }
            return details;
        }

        public void AddToClass(string nameClass)
        {
            IsRegisteredClass = true;
            NameOfClassRegistered = nameClass;
        }

        public void RemoveFromClass()
        {
            IsRegisteredClass = false;
            NameOfClassRegistered = null;
        }

        public double AverageAfterDropLowestGrade()
        {
            Dictionary<string, double> newGrades = new Dictionary<string, double>(Grades);

            newGrades.Remove(newGrades.FirstOrDefault(x => x.Value == newGrades.Min(y => y.Value)).Key);
            return newGrades.Average(x => x.Value);
        }
    }
}
