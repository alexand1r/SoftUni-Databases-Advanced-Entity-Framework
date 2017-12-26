using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace zadacha1
{
    class zadacha1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Postnumerandna renta");
            Console.WriteLine("2. Prenumerandna renta");
            Console.WriteLine("3. Opredelqne sroka na rentata");
            Console.WriteLine();
            Console.Write("Izberete operaciq: ");

            while (true)
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        ResultForFirst();
                        break;
                    case "2":
                        ResultForSecond();
                        break;
                    case "3":
                        ResultForThird();
                        break;
                    default:
                        Console.WriteLine("Nevalidna opraciq!");
                        break;
                }
            }
        }

        private static void ResultForThird()
        {
            List<double> data = FirstAndSecondMethod();
            double Sn = data[0];
            double R = data[1];
            double i = data[2];
            double n = Formula3(Sn, R, i);
            Console.WriteLine($"Srokyt na rentata n = {Sn}");
            Console.WriteLine();
            Console.Write("Moje da izberete druga operaciq: ");
        }

        private static void ResultForFirst()
        {
            List<double> data = FirstAndSecondMethod();
            double n = data[0];
            double R = data[1];
            double i = data[2];
            double Sn = Formula1(n, R, i);
            Console.WriteLine($"Narasnalata suma Sn = {Sn}");
            Console.WriteLine();
            Console.Write("Moje da izberete druga operaciq: ");
        }

        private static void ResultForSecond()
        {
            List<double> data = FirstAndSecondMethod();
            double n = data[0];
            double R = data[1];
            double i = data[2];
            double Sn = Formula2(n, R, i);
            Console.WriteLine($"Narasnalata suma Sn = {Sn}");
            Console.WriteLine();
            Console.Write("Moje da izberete druga operaciq: ");
        }

        private static double Formula1(double n, double R, double i)
        {
            return R * ((Math.Pow(i + 1, n) - 1) / i);
        }

        private static double Formula2(double n, double R, double i)
        {
            return R * (i + 1) * ((Math.Pow(i + 1, n) - 1) / i);
        }

        private static double Formula3(double n, double R, double i)
        {
            //return R * (i + 1) * (Math.Pow(i + 1, n - 1) / i);
            return 0;
        }

        private static List<double> FirstAndSecondMethod()
        {
            List<double> parameters = new List<double>();

            Console.WriteLine();
            Console.WriteLine("Prodyljitelnost na rentnite plashtaniq");

            Console.Write("n(godini) = ");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Sumata na vsqko edno rentno plashtane");

            Console.Write("R(leva) = ");
            double R = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Godishna lihva");

            Console.Write("i(%) = ");
            double i = double.Parse(Console.ReadLine()) / 100d;
            Console.WriteLine();

            parameters.Add(n);
            parameters.Add(R);
            parameters.Add(i);

            return parameters;
        }

        private static List<double> ThirdMethod()
        {
            List<double> parameters = new List<double>();

            Console.WriteLine();
            Console.WriteLine("Narastnala suma na rentata sled n-godishni plashtaniq");

            Console.Write("Sn(leva) = ");
            double Sn = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Sumata na vsqko edno rentno plashtane");

            Console.Write("R(leva) = ");
            double R = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Godishna lihva");

            Console.Write("i(%) = ");
            double i = double.Parse(Console.ReadLine()) / 100d;
            Console.WriteLine();

            parameters.Add(Sn);
            parameters.Add(R);
            parameters.Add(i);

            return parameters;
        }
    }
}
