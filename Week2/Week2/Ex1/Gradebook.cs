using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Gradebook
    {
        #region Constant Fields
        #region public

        #endregion

        #region private

        #endregion
        #endregion

        #region Fields
        #region public

        #endregion

        #region private
        private string courseName;

        #endregion
        #endregion

        #region Constructors

        #endregion
        public Gradebook(string name)
        {
            CourseName = name;
        }

        #region Destructors

        #endregion

        #region Properties
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        #endregion

        #region Methods
        #region public
        public void DisplayMessage()
        {
            Console.WriteLine($"Welcome to {courseName} Gradebook!\n");
        }

        #endregion

        #region private

        #endregion
        #endregion

    }
}
