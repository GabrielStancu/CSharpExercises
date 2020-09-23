using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CSharpExercises
{
    class TasksDemo
    {
        private Task task8;
        private System.Timers.Timer timer;

        public void Run()
        {
            Task task1 = new Task(new Action(SayHi));
            task1.Start();

            Task task2 = new Task(delegate ()
            {
                Console.WriteLine("Task 2 is starting.");
                Console.WriteLine("Task 2 is running.");
                Console.WriteLine("Hi there from task 2!");
                Thread.Sleep(7000);
                Console.WriteLine("Task 2 is complete!");
            });
            task2.Start();

            Task task3 = new Task(() =>
            {
                Console.WriteLine("Task 3 is starting.");
                Console.WriteLine("Task 3 is running.");
                Console.WriteLine("Hi there from task 1!");
                Thread.Sleep(3000);
                Console.WriteLine("Task 3 is complete!");
            });
            task3.Start();

            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");

            Task task4 = new Task(new Action<object>(Greet), new object[] { "Gabi", DateTime.Now });
            task4.Start();

            Task task5 = new Task(delegate (object name)
            {
                Console.WriteLine($"Welcome back, {name}");
            }, "Razvan");
            task5.Start();

            Task task6 = new Task(n =>
            {
                Console.WriteLine($"Welcome back, {n}");
            }, "Andra");
            task6.Start();

            Task<int> task7 = new Task<int>(() =>
            {
                int result = 0;
                for (int i = 0; i < 20; i++)
                {
                    result += i;
                }

                return result;
            });
            task7.Start();

            Console.WriteLine($"The sum is {task7.Result}");

            task8 = new Task(() =>
            {
                for (int i = 0; i < 5_000; i++)
                {
                    Console.WriteLine(i);
                }
            });
            task8.Start();

            timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task task9 = new Task(() =>
            {
                for (int i = 0; i < 100_000; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("The task is cancelled!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(i + 1);
                    }
                }

                Console.WriteLine("The task is completed!");
            });

            task9.Start();

            Thread.Sleep(2500);
            cancellationTokenSource.Cancel();

            Task.WaitAny(task6, task7, task8);
            Task.WaitAll(task6, task9);

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"Not instantiated task: {i + 1}");
                }
            });

            RunTask();

            ConcurrentTasks();

            Console.ReadLine();
        }

        private void ConcurrentTasks()
        {
            CancellationTokenSource ts1 = new CancellationTokenSource();
            CancellationToken token1 = ts1.Token;

            CancellationTokenSource ts2 = new CancellationTokenSource();
            CancellationToken token2 = ts2.Token;

            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 has started.");

                for (int i = 0; i<1_000_000; i++)
                {                   
                    if(token1.IsCancellationRequested)
                    {
                        Console.WriteLine($"The value task 1 has reached is {i}");
                        return;
                    }
                }

                Console.WriteLine("Task 1 is complete!");
                ts2.Cancel();
            });

            Task t2 = new Task(() =>
            {
                Console.WriteLine("Task 2 has started.");

                for (int i = 0; i < 1_000_000; i++)
                {
                    if (token2.IsCancellationRequested)
                    {
                        Console.WriteLine($"The value task 2 has reached is {i}");
                        return;
                    }
                }

                Console.WriteLine("Task 2 is complete!");
                ts1.Cancel();
            });

            t1.Start();
            t2.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(task8.Status == TaskStatus.Running)
            {
                Console.WriteLine("Task is running...");
            }
            else if(task8.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine("Task has finished.");
                timer.Enabled = false;
            }
        }

        private void SayHi()
        {
            Console.WriteLine("Task 1 is starting.");
            Console.WriteLine("Task 1 is running.");
            Console.WriteLine("Hi there from task 1!");
            Thread.Sleep(5000);
            Console.WriteLine("Task 1 is complete!");
        }

        private void Greet(object args)
        {
            var parameters = (object[])args;
            var name = (string)parameters[0];
            var moment = (DateTime)parameters[1];
            Console.WriteLine($"Welcome back, {name}, at {moment}");
        }

        private Task RunTask()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("I am running outside, will be returned!");
            });
        }
    }
}
