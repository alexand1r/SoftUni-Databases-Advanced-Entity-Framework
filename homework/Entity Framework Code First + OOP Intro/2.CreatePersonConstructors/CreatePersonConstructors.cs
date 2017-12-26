using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CreatePersonConstructors
{
    class CreatePersonConstructors
    {
        static void Main(string[] args)
        {
            Person first = new Person("Pesho", 20);
            Person second = new Person("Gosho");
            Person third = new Person(43);
            Person fourth = new Person();

            Console.WriteLine($"{first.Name} {first.Age}");
            Console.WriteLine($"{second.Name} {second.Age}");
            Console.WriteLine($"{third.Name} {third.Age}");
            Console.WriteLine($"{fourth.Name} {fourth.Age}");
        }

        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public Person() : this("No name", 1) {}
            public Person(string name)
            {
                this.Name = name;
                this.Age = 1;
            }
            public Person(int age)
            {
                this.Name = "No name";
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
