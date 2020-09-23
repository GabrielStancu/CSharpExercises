using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpExercises
{
    class ConcurrentCollectionsDemo
    {
        public void Run()
        {
            ConcurrentBagDemo();
            ConcurrentStackDemo();
        }

        private void ConcurrentStackDemo()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            Thread t1 = new Thread(() =>
            {
                int[] t1Numbers = new int[] { 16, 3, 15, 20, 98 };

                foreach (var nr in t1Numbers)
                {
                    stack.Push(nr);
                }
            });

            Thread t2 = new Thread(() =>
            {
                int[] t2Numbers = new int[] { 61, 30, 51, 89 };
                

                foreach (var nr in t2Numbers)
                {
                    stack.Push(nr);
                    
                }

                
            });

            Thread t3 = new Thread(() =>
            {
                int accessTimes = 0;
                while (!stack.IsEmpty)
                {
                    stack.TryPop(out int nr);
                    accessTimes++;
                }
                Console.WriteLine($"Thread 3 has accessed the stack {accessTimes} times.");
            });

            Thread t4 = new Thread(() =>
            {
                int accessTimes = 0;
                while (!stack.IsEmpty)
                {
                    stack.TryPop(out int nr);
                    accessTimes++;
                }
                Console.WriteLine($"Thread 4 has accessed the stack {accessTimes} times.");
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
        }

        private void ConcurrentBagDemo()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Thread t1 = new Thread((object threadNr) =>
            {
                Console.WriteLine($"Thread ({threadNr}) has started.");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Thread ({threadNr}) adding the number {i} to the bag...");
                    bag.Add(i);
                }
                Console.WriteLine($"Thread ({threadNr}) is complete.");
            });

            Thread t2 = new Thread((object threadNr) =>
            {
                Console.WriteLine($"Thread ({threadNr}) has started.");
                for (int i = 11; i <= 25; i++)
                {
                    Console.WriteLine($"Thread ({threadNr}) adding the number {i} to the bag...");
                    bag.Add(i);
                }
                Console.WriteLine($"Thread ({threadNr}) is complete.");
            });

            Thread t3 = new Thread((object threadNr) =>
            {
                t1.Join();
                t2.Join();
                Console.WriteLine($"Thread ({threadNr}) has started.");
                foreach (var item in bag)
                {
                    Console.WriteLine($"Thread ({threadNr}) got the number {item} from the bag...");
                }
                Console.WriteLine($"Thread ({threadNr}) is complete.");
            });

            t1.Start(1);
            t2.Start(2);
            t3.Start(3);
        }
    }
}
