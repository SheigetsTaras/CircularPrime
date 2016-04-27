using System;

namespace CircularPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
           
            try
            {
                if (args.Length != 0)
                {
                    value = Convert.ToInt32(args[0]);
                }
                else
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                CalcCircularPrime calcCircularPrime = new CalcCircularPrime();
                if(calcCircularPrime.Start(value))
                    calcCircularPrime.PrintResult();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
