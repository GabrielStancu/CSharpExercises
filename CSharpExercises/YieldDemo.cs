using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class YieldDemo
    {
        public void Run()
        {
            foreach (var item in PerformMathOperations(3,2))
            {
                Console.WriteLine(item);
            }
        }

        private IEnumerable<double> PerformMathOperations(int noOne, int noTwo)
        {
            yield return noOne + noTwo;
            yield return noOne - noTwo;
            yield return noOne * noTwo;
            yield return Math.Round((double)noOne / (double)noTwo, 2);
        }
    }
}
