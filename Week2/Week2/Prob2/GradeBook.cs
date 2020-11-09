using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob2
{
    public class GradeBook
    {
        #region Fields
        #region public

        #endregion

        #region private
        private string courseName;
        private string instructorName;
        private int courseStart;

        #endregion
        #endregion

        #region Constructors
        public GradeBook(string courseName, string instructorName)
        {
            CourseName = courseName;
            InstructorName = instructorName;
            courseStart = 1982;
        }

        #endregion

        #region Properties
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public string InstructorName
        {
            get { return instructorName; }
            set { instructorName = value; }
        }

        public int CourseStart
        {
            get { return courseStart; }
            private set { courseStart = value; }
        }

        #endregion

        #region Methods
        #region public
        public void DisplayMessage()
        {
            Console.WriteLine($"Welcome to the grade book for\n{CourseName}!");
            Console.WriteLine($"This course is presented by:\n{InstructorName}!");
        }

        public (int CourseStart, string CourseName, string InstructorName) GradeBookTitle()
        {
            (int CourseStart, string CourseName, string InstructorName) result = (CourseStart, CourseName, InstructorName);

            return result;
        }

        public void ChangeCourseTitle((string CourseName, string InstructorName) title)
        {
            CourseName = title.CourseName;
            InstructorName = title.InstructorName;
        }

        #endregion

        #region private

        #endregion

        #endregion
    }
}