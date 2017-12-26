namespace _4.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Students
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                students.Add(new Student(cmd));
                cmd = Console.ReadLine();
            }
            Console.WriteLine(Student.count);
        }

        public class Student
        {
            public static int count = 0;
            public string Name { get; set; }

            public Student(string Name)
            {
                this.Name = Name;
                count++;
            }
        }
    }
}
