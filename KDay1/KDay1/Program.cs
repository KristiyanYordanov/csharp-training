using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 



 
namespace KDay1
{
    class Program
    {
        static void Main(string[] args)
        {
          
             Console.Write("entering the number of courses=");
            int size = 0;
            Int32.TryParse(Console.ReadLine(), out size);

            Academy academy = new Academy();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>(size);
            
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("\ncourseName//duration//capacity=");
                Course course = new Course();
                string[] cc = Console.ReadLine().Split('/');
                course.Name = cc[0];
                int duration = 0;
                int capacity = 0;
                Int32.TryParse(cc[1], out duration);
                Int32.TryParse(cc[2], out capacity);
                course.Duration = duration;
                course.MaxCapacity = capacity;
                course.Capacity = 0;
           
                Console.Write(course);
                courses.Add(course);
            }


            Console.Write("entering the number of students=");
            int studentSize = 0;
            Int32.TryParse(Console.ReadLine(), out studentSize);

            Console.WriteLine("\nname//age");
            string text = Console.ReadLine();

            for (int i = 0; i < studentSize; i++)
            {
                string[] p = text.Split('/');
                Student student = new Student(p[0], UInt16.Parse(p[1]));
                students.Add(student);
            text = Console.ReadLine();
            }

         
            Console.WriteLine("studentID courseID");
            string signUps = Console.ReadLine();
            while (!signUps.Equals("quite"))
            {
                try
                {
                    string[] cc = signUps.Split(' ');
                    int studentID;
                    int courseID;
                    Int32.TryParse(cc[0], out studentID);
                    Int32.TryParse(cc[1], out courseID);

                  
                    Student student = new Student(studentID);
                  
                   
                    if (!students.Contains(student))
                    {
                        throw new Exception("Student does not exist");
                    }
                    else
                    {
                        student = (from n
                       in students where n.Id == studentID
                                  select n).First();
                    }

                    Course currentCourse = new Course(courseID);
                    if (!courses.Contains(currentCourse))
                    {
                        throw new Exception("Course does not exist");
                    }
                    else
                    {
                        currentCourse = (from n
                                in courses
                                   where n.Id == courseID
                                   select n).First();
                    }

                   
                    if (academy.EnrolledStudents.Contains(student))
                    {
                        throw new Exception("Student is already signed upStudent is already signed up");
                    }
                    


                    if (currentCourse.Capacity >= currentCourse.MaxCapacity)
                    {
                        throw new Exception("Course "+ currentCourse.Name+ " is already full!");
                    }


                 
                    currentCourse.Capacity++;
                 

                    bool isEnrolled =  currentCourse.isStudentEnrolled(student);
                    if (!isEnrolled)
                    {
                       // Console.WriteLine("\n signup: " + studentID + " : " + courseID);
                        currentCourse.signUp(student);
                        academy.EnrolledStudents.Add(student);
                  }

                    

                    signUps = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Error:" + e.Message);
                    signUps = Console.ReadLine();
                }
            }
            
            var coursecFinal = from n
                       in courses
                       orderby n.Name ascending
                         select n;

           //courses.Sort(((x,y) => x.Name.CompareTo(y.Name)));

            foreach (var cc in coursecFinal)
            {
                Console.WriteLine("\n"+cc.Name + " - "  + cc.Duration  + " hours");

                var studentFinal = from n
                     in cc.Students
                                   orderby n.Age ascending
                                   select n;

                foreach (var st in studentFinal)
                {
                    Console.WriteLine("\n##" + st);
                }
                Console.WriteLine();

            }

           









            Console.ReadLine();
        }

      
    }

    
}
