using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpExercises
{
    class IEnumerableDemo
    {
        public void Run()
        {
            IEnumerable<int> result = from value in Enumerable.Range(1, 10)
                                      select value;

            foreach(var value in result)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();

            double avg = result.Average();
            Console.WriteLine($"Average = {avg}");

            List<int> list = result.ToList();
            int[] array = result.ToArray();

            list.Add(11);
            list.Add(12);
            list.Add(13);

            Console.WriteLine("What's in the list now?");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("What's in the IEnumerable now?");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            result = list.AsEnumerable();
            Console.WriteLine("What's in the IEnumerable now?");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------");

            IEnumerator<int> enumerator = list.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
