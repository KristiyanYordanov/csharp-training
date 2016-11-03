using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDay1
{
    class Course
    {
        private static int LastID = 0;
        private long id;
        private int capacity;
        private int maxCapacity;
        private List<Student> students = new List<Student>();
        private string name;
        private int duration;





        public Course()
        {
            Id = LastID++;
        }

        public Course(int courseID)
        {
            Id = courseID;
        }

        public long Id
        {
            get { return id; }
            private set { id = value; }
        }

        public int MaxCapacity
        {
            get { return maxCapacity; }
            set { maxCapacity = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }


        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(capacity)}: {capacity}, {nameof(maxCapacity)}: {maxCapacity}, {nameof(name)}: {name}, {nameof(duration)}: {duration}";
        }

        public bool isStudentEnrolled(Student student)
        {
            foreach (var s in Students)
            {
                if (s.Id == student.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public void signUp(Student student)
        {
            students.Add(student);
        }

        public void remove(Student student)
        {
            students.Remove(student);
        }

        protected bool Equals(Course other)
        {
            return id == other.id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Course) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
