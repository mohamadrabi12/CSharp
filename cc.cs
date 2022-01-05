using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Course
    {
        private Students student; 
        private string courseName;

        public class Students
        {
            private string studentName;
            private List<int> grades = new List<int>();

            #region set&get
            public string StudentName
            {
                get => studentName;
                set => studentName = value;
            }
            public List<int> Grades
            {
                get => grades;
                set => grades = value;
            }
            #endregion

            public bool passingAverage()
            {
                float avre = 0;
                int counter = 0;
                foreach (int grade in grades)
                {
                    if (grade >= 60)
                    {
                        avre += grade;
                        counter++;
                    }
                }
                return (avre / counter) >= 70;
            }
            public override string ToString()
            {
                string str = "";
                foreach (int grade in grades)
                {
                    str += grade + " ";
                }
                str =String.Format("{0,-10} {1,-10}", studentName, str);
                return str;
            }
        }
        #region set&get
        public string CourseName
        {
            get => courseName;
            set => courseName = value;
        }
        public Students Student
        {
            get => student;
            set => student = value;
        }
        #endregion

        public int ShowGrade(int Location)
        {
            return student.Grades[Location];
        }

        public override string ToString()
        {
            return String.Format("{0,-10} {1,-10}",courseName, student.ToString());
        }

    }
}
