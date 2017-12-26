namespace _3.OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string name = data[0];
                int age = int.Parse(data[1]);
                family.AddMember(new Person(name, age));
            }
            Person test = family.GetOldestMember();
            Console.WriteLine($"{test.Name} {test.Age}");
        }
        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Family
        {
            private ICollection<Person> members;

            public Family()
            {
                this.members = new HashSet<Person>();
            }

            public virtual ICollection<Person> Members
            {
                get { return this.members; }
                set { this.members = value; }
            }

            public void AddMember(Person person)
            {
                Members.Add(person);
            }

            public Person GetOldestMember()
            {
                Person oldest = Members.OrderByDescending(m => m.Age).FirstOrDefault();
                return oldest;
            }

        }
    }
}
