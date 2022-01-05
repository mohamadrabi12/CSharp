using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of courses: \n");
            List<Course> courses =  initData();

            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\n\nPress P / p : Those who passed in average and those who did not:");
            Console.WriteLine("Press # : C# courses, and other courses:");
            Console.WriteLine("Any other key: Courses with student who have at least one grade of 100, and all the other courses:");
            char choice =Console.ReadKey().KeyChar;

            Console.WriteLine("\n\nQ1 Results: \n");
            Predicate<Course> predicate;
            List<List<Course>> ListOfCourses;
            switch (choice)
            {
                case 'P':
                case 'p':
                    predicate = CheckAverage;
                    ListOfCourses = Q1(courses, predicate);
                    break;
                case '#':
                    predicate = CheckCs;
                    ListOfCourses = Q1(courses, predicate);
                    break;
                default:
                    predicate = Check100;
                    ListOfCourses = Q1(courses, predicate);
                    break;
            }
            printCourses(ListOfCourses);

            try
            {
                Console.WriteLine("\nlist[1].ShowGrade(0)");
                Console.WriteLine(courses[1].ShowGrade(0));
            }
            catch (ArgumentOutOfRangeException)
            {
                ;
            }
            try
            {
                Console.WriteLine("\nlist[2].ShowGrade(3)");
                Console.WriteLine(courses[2].ShowGrade(3));
            }
            catch (ArgumentOutOfRangeException)
            {
                ;
            }
            List<Course> exceptionalList = Q2(courses);
            printExceptional(exceptionalList);
            Console.ReadLine();
        }

        #region print
        private static void printExceptional(List<Course> exceptionalList)
        {
            Console.WriteLine("\n\n");
            foreach (Course course in exceptionalList)
            {
                string str = "";
                foreach (int item in course.Student.Grades)
                {
                    str += item.ToString() + " ";
                }
                Console.WriteLine("{ Name = "+course.Student.StudentName + " , List = "+str +"}");
            }
        }
        private static void printCourses(List<List<Course>> listOfCourses)
        {
            Console.WriteLine("\nFalse \n---------");
            foreach (Course item in listOfCourses[0])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nTrue \n---------");
            foreach (Course item in listOfCourses[1])
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        private static List<Course> Q2(List<Course> courses)
        {
            return courses.Where(c => c.Student.passingAverage()).Select(c => c).ToList();
        }

        #region PredicatesForQ1
        private static bool CheckAverage(Course course)
        {
            bool flag = false;
            
            float avr = 0;
            foreach (int Grade in course.Student.Grades)
            {
                avr += Grade;
            }
            if (course.Student.Grades.Count == 0)
                return false;
            avr /= course.Student.Grades.Count;
            if (avr >= 60)
                flag = true;
            return flag;
        }
        private static bool CheckCs(Course course)
        {
            if (course.CourseName == "c#")
                return true;
            return false;
        }
        private static bool Check100(Course course)
        {
            bool flag = false;
            foreach (int grade in course.Student.Grades)
            {
                if (grade == 100)
                    flag = true;
            }
            
            return flag;
        }
        #endregion

        private static List<List<Course>> Q1<Course>(List<Course> courses, Predicate<Course> predicate)
        {
           

            var item =(courses.Where(c => predicate(c)).Select(c =>c).ToList(),
                        courses.Where(c => !predicate(c)).Select(c => c).ToList());
            List<List<Course>> list = new List<List<Course>>();
            list.Add(item.Item2);
            list.Add(item.Item1);
            return list;
        }

        private static List<Course> initData()
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Course() { CourseName = "cyber", Student = new Course.Students() {StudentName = "lotfi", Grades = new List<int>() {20,20,100 } } });
            courses.Add(new Course() { CourseName = "math", Student = new Course.Students() { StudentName = "samerj3fr", Grades = new List<int>() { 99 } } });
            courses.Add(new Course() { CourseName = "eng", Student = new Course.Students() { StudentName = "absi", Grades = new List<int>() } });
            courses.Add(new Course() { CourseName = "html", Student = new Course.Students() { StudentName = "Asl", Grades = new List<int>() { 60, 30,55,40 } } });
            courses.Add(new Course() { CourseName = "css", Student = new Course.Students() { StudentName = "raft", Grades = new List<int>() {100,99,1,90,100 } } });
            courses.Add(new Course() { CourseName = "java", Student = new Course.Students() { StudentName = "absi", Grades = new List<int>() { 30,70,80,1 } } });
            courses.Add(new Course() { CourseName = "javascript", Student = new Course.Students() { StudentName = "moha", Grades = new List<int>() { 40 } } });
            return courses;
        }
    }
}
