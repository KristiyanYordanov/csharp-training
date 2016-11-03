using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDay1
{
    class Academy
    {
        private List<Course> courses;
        private List<Student> students;
        private List<Student> enrolledStudents = new List<Student>();

        public List<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public List<Student> EnrolledStudents
        {
            get { return enrolledStudents; }
            set { enrolledStudents = value; }
        }
    }
}
