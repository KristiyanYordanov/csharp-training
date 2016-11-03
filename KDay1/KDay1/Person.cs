using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDay1
{
    class Person
    {
        private string name;
        private uint age;
        public string Name { get; set; }
        public uint Age { get; set; }

        public Person()
        {
            Name = "No name";
            Age = 1;
           // Console.WriteLine(this);
        }

        public Person(string name, uint age) : this(name)
        {
            Name = name;
            Age = age;
            //Console.WriteLine(this);
        }

        public Person(string name) :this()
        {
            Name = name;
          //  Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}
