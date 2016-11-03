using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDay1
{
    class Student :Person
    {
        private static int LastID = 0;
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }


        public Student(string name, uint age) : base(name, age)
        {
            Id = LastID++;
        }

        public Student(int studentID)
        {
            Id = studentID;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Id)}: {Id}";
        }

        protected bool Equals(Student other)
        {
            return id == other.id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        private sealed class IdEqualityComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.id == y.id;
            }

            public int GetHashCode(Student obj)
            {
                return obj.id.GetHashCode();
            }
        }

        private static readonly IEqualityComparer<Student> IdComparerInstance = new IdEqualityComparer();

        public static IEqualityComparer<Student> IdComparer
        {
            get { return IdComparerInstance; }
        }

    }
}
