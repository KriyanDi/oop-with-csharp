using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook myGradeBook = new GradeBook("C# .Net", "Evgenii Krustev");

            Console.WriteLine($"CourseName: {myGradeBook.CourseName}");
            Console.WriteLine($"InstructorName: {myGradeBook.InstructorName}");
            Console.WriteLine($"CourseStart: {myGradeBook.CourseStart}");

            myGradeBook.DisplayMessage();

            (string, string) title = ("OOP with C# .NET", "Evgenii Hristov Krustev");
            myGradeBook.ChangeCourseTitle(title);

            (int CourseStart, string CourseName, string InstructorName) gradeBookTitle = myGradeBook.GradeBookTitle();
            Console.WriteLine($"CourseName: {gradeBookTitle.CourseName}");
            Console.WriteLine($"InstructorName: {gradeBookTitle.InstructorName}");
            Console.WriteLine($"CourseStart: {gradeBookTitle.CourseStart}");
        }
    }
}
