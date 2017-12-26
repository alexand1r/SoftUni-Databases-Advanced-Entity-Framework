namespace _5.PlanckConstant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class PlanckConstant
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.reducedPlanck());
        }

        public class Calculation
        {
            public static double planckConst = 6.62606896e-34;
            public static double piConst = 3.14159;

            public static double reducedPlanck()
            {
                var result = (planckConst / (2 * piConst));
                return result;
            }
        }
    }
}
