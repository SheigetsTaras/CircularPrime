using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CircularPrime
{
    class CalcCircularPrime
    {
        private List<int> _primeList;
        private Stopwatch _timeAlgorithm;

        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2; //return true , because 2 is prime number
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }


        private int Rotate(int iNumber)
        {
            double givenNo = iNumber;
            int reminder = (int)iNumber % 10;
            int quotient = (int)iNumber / 10;
            return Convert.ToInt32((reminder * Math.Pow(10, iNumber.ToString().Length - 1)) + quotient);
        }


        private void FindCircular(int primeNumber)
        {
            var res = primeNumber;
            List<int> resultList = new List<int>() { primeNumber };

            for (int i = 0; i < primeNumber.ToString().Length - 1; i++)
            {
                res = Rotate(res);

                if (IsPrime(res))
                {
                    if (!resultList.Contains(res) || res == primeNumber)  //(res == primeNumber - used for checking numbers like 111, 333)
                        resultList.Add(res);
                }
            }

            if (resultList.Count == (primeNumber.ToString().Length))
            {
                resultList = resultList.Distinct().ToList();
                _primeList.AddRange(resultList);
            }
        }


        public void PrintResult()
        {
            Console.Write("Circular Prime numbers: ");
            foreach (var pr in _primeList)
            {
                Console.Write(pr + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Total Circular Prime numbers: " + _primeList.Count);
            Console.WriteLine("Elapsed time " + _timeAlgorithm.Elapsed.TotalSeconds);
        }


        public bool Start(int value)
        {
            if (value > 0)
            {
                _primeList = new List<int>();
                _timeAlgorithm = Stopwatch.StartNew();
                for (int i = 0; i < value; i++)
                {
                    if (!_primeList.Contains(i) && IsPrime(i))
                    {
                        FindCircular(i);
                    }
                }
                _timeAlgorithm.Stop();

                _primeList.Sort();

                return true;
            }
            else
            {
                Console.WriteLine("The number must be greater than zero!");
                return false;
            }
          

        }
    }
}
