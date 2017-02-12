using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lamda Expression 
            //var studentWithTCharacters = students.FindAll(s => s.First[0].ToString() == "S");
            //LINQ Lambda way
            //var studentWithTCharacters = students.Where(s => s.First[0].ToString() == "S");
            //LINQ Query way

            var studentWithTCharacters = from s in students
                                         where s.First[0].ToString() == "S"
                                         select s;

            foreach (var student in studentWithTCharacters)
            {
                Console.WriteLine("Student name is {0} {1}", student.First, student.Last);
            }

            var maxScore = students.Max(s => s.Scores.Sum());
            var studentWithMaxScore = students.FindAll(s => s.Scores.Sum().Equals(maxScore));
            StringBuilder str = new StringBuilder();
            if (studentWithMaxScore.Count > 1)
                str.Append("\nStudents with highest Score\n");
            else
                str.Append("\nThe student with highest Score\n");


            foreach (var student in studentWithMaxScore)
            {
                str.Append(student.First);
                str.Append("\t");
                str.Append(student.Last);
                str.Append("\n");
            }
            Console.WriteLine(str.ToString());

            //Display students with first name length greater than 10
            var studentWithFNMoreThan10 = students.FindAll(s => s.First.Length > 10);
            StringBuilder str1 = new StringBuilder();
            if (studentWithFNMoreThan10.Count == 0)
                str1.Append("There are no students with First Names' length greater than 10\n");
            else
                str1.Append("Students with First Names' length is greater than 10\n");

            foreach (var student in studentWithFNMoreThan10)
            {
                str1.Append(student.First);
                str1.Append("\t");
                str1.Append(student.Last);
                str1.Append("\n");
            }
            Console.WriteLine("\n" + str1.ToString());


            //Display student with total score greater than 270

            var studentWithTotalScoreGreater270 = students.FindAll(s => s.Scores.Sum().Equals(270));
            StringBuilder str2 = new StringBuilder();
            if (studentWithTotalScoreGreater270.Count > 1)
                str2.Append("Students with score greater than 270\n");
            else
                str2.Append("The student with score greater than 270\n");


            foreach (var student in studentWithMaxScore)
            {
                str2.Append(student.First);
                str2.Append("\t");
                str2.Append(student.Last);
                str2.Append("\n");
            }
            Console.WriteLine("\n" + str2.ToString());

            //Print students with reversed name
            StringBuilder str3 = new StringBuilder();
            str3.Append("\nStudents in reversed\n");
            foreach (var student in students)
            {
                str3.Append(student.First.ToCharArray().Reverse().ToArray());
                str3.Append("\t");
                str3.Append(student.Last.ToCharArray().Reverse().ToArray());
                str3.Append("\t");
                str3.Append(student.ID);
                str3.Append("\t");
                int sumS = student.Scores.Sum();
                str3.Append(sumS);
                str3.Append("\n");
            }
            Console.WriteLine(str3.ToString());

            //Generate student to a new List object and the object have FirstName and LastName property

            var newStudentList = students.Select(x => new { FirstName = x.First, LastName = x.Last }).ToList();
            StringBuilder str4 = new StringBuilder();
            str4.Append("\nNew Student List\n");
            foreach (var student in newStudentList)
            {
                str4.Append(student.FirstName);
                str4.Append("\t");
                str4.Append(student.LastName);
                str4.Append("\n");
            }
            Console.WriteLine(str4.ToString());

            //Print students with First name Descending order
            var descendingOrder = students.OrderByDescending(student => student.First);
            StringBuilder str5 = new StringBuilder();
            str5.Append("\nStudent List Order By FirstName Descending Order\n");
            foreach (var student in descendingOrder)
            {
                str5.Append(student.First);
                str5.Append("\t");
                str5.Append(student.Last);
                str5.Append("\n");
            }
            Console.WriteLine(str5.ToString());


            //Print students with Last name Ascending order
            var ascendingOrder = students.OrderBy(student => student.Last);
            StringBuilder str6 = new StringBuilder();
            str5.Append("\nNew Student List Order By Last Name Ascending Order\n");
            foreach (var student in ascendingOrder)
            {
                str5.Append(student.First);
                str5.Append("\t");
                str5.Append(student.Last);
                str5.Append("\n");
            }
            Console.WriteLine(str5.ToString());


            Console.ReadKey();
        }

        static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };

    }

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    // Create a data source by using a collection initializer.

}
