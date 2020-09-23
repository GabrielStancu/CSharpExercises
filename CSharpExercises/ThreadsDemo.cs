using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpExercises
{
    class ThreadsDemo
    {
        public Object myLock = new Object();
        Mutex mutex = new Mutex();
        Semaphore semaphore = new Semaphore(2, 2);
        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;
        public void Run()
        {
            t1 = new Thread(new ThreadStart(SayHiEnglish));
            t1.Name = "Thread Number 1 (English)";
            t1.Start();

            t2 = new Thread(new ThreadStart(SayHiSpanish));
            t2.Name = "Thread Number 2 (Spanish)";
            t2.Start();

            t3 = new Thread(new ThreadStart(() => Console.WriteLine("I am the required message from the lambda expression!")));
            t3.Start();

            t4 = new Thread(new ThreadStart(delegate ()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("I am the required message from the anonymous function!");
                }
            }));
            t4.Start();

            t5 = new Thread(new ParameterizedThreadStart(Loop));
            t5.Start(100);

            Thread[] threads1 = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads1[i] = new Thread(new ParameterizedThreadStart(Write));
                threads1[i].Start($"c:\\file{i}.txt");
            }

            Thread[] threads2 = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads2[i] = new Thread(new ParameterizedThreadStart(Read));
                threads2[i].Start($"c:\\file{i}.txt");
            }

            Thread[] threads3 = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads3[i] = new Thread(new ThreadStart(EnterMutexArea));
                threads3[i].Name = $"Thread#{i}";
                threads3[i].Start();
            }

            Thread[] threads4 = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads4[i] = new Thread(new ThreadStart(EnterSemaphoreArea));
                threads4[i].Name = $"Thread#{i}";
                threads4[i].Start();
            }
        }

        private void SayHiEnglish()
        {
            Console.WriteLine("Starting to execute " + Thread.CurrentThread.Name);
            for(int i = 0; i < 50; i++)
            {
                if (i == 31)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + "is about to be aborted.");
                    //t1.Abort();
                }
                t2.Join();
                Console.WriteLine(i + "Hi...");
            }
        }

        private void SayHiSpanish()
        {
            Console.WriteLine("Starting to execute " + Thread.CurrentThread.Name);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i + "Hola...");
            }
        }

        private void Loop(object number)
        {
            for (int i = 0; i < int.Parse(number.ToString()); i++)
            {
                Console.WriteLine("Parameterized value is now: " + i);
            }
        }

        private void Write(object path)
        {
            lock(myLock)
            {
                Console.WriteLine("Writing in " + path);
                Thread.Sleep(2000);
                Console.WriteLine("Writing process is complete!");
            }
        }

        private void Read(object path)
        {
            Monitor.Enter(path);
            try
            {
                Console.WriteLine("Reading from " + path);
                Thread.Sleep(2000);
                Console.WriteLine("Reading process is complete!");
            }
            finally
            {
                Monitor.Exit(path);
            }                 
        }

        private void EnterMutexArea()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex.");
            mutex.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the critical region.");
            Thread.Sleep(2000);
            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the critical region.");

            mutex.ReleaseMutex();
            Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex.");
        }

        private void EnterSemaphoreArea()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is requesting the mutex.");
            semaphore.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the critical region.");
            Thread.Sleep(2000);
            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the critical region.");

            semaphore.Release();
            Console.WriteLine($"{Thread.CurrentThread.Name} has released the mutex.");
        }
    }
}
