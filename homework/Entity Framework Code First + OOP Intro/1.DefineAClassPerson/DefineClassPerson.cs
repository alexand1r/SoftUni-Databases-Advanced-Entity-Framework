namespace _1.DefineAClassPerson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class DefineClassPerson
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", 21);
            Person misho = new Person();

            Console.WriteLine(pesho.Name);
            Console.WriteLine(pesho.Age);
            Console.WriteLine(misho.Name);
        }
        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public Person() : this("Vanilla", 3) {}

            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
