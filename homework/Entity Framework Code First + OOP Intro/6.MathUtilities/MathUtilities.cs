namespace _6.MathUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class MathUtilities
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] data = cmd.Split(' ');
                string action = data[0];
                double num1 = double.Parse(data[1]);
                double num2 = double.Parse(data[2]);
                switch (action)
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(num1, num2):F2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Subtract(num1, num2):F2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(num1, num2):F2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(num1, num2):F2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percentage(num1, num2):F2}");
                        break;
                }
                cmd = Console.ReadLine();
            }
        }

        public class MathUtil
        {
            public static double Sum(double num1, double num2)
            {
                return num1 + num2;
            }
            public static double Subtract(double num1, double num2)
            {
                return num1 - num2;
            }
            public static double Multiply(double num1, double num2)
            {
                return num1 * num2;
            }
            public static double Divide(double dividend, double divisor)
            {
                return dividend / divisor;
            }
            public static double Percentage(double num, double percent)
            {
                return (percent/100)*num;
            }
        }
    }
}
