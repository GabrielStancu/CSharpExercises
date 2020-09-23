using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpExercises
{
    class AsyncAwaitDemo
    {
        public void Run()
        {
            Console.WriteLine("First we are inside the main method...");

            RunProcess(1, 1_000_000);

            var backgroundProcess = PerformBackgroundOperation();
            if(backgroundProcess.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine("The background process is complete!");
            }
            else if (backgroundProcess.Status == TaskStatus.Running)
            {
                Console.WriteLine("The background process is NOT complete!");
            }

            Console.WriteLine("Back to the main method...");

            RunProcess(2, 1_500_000);

            Console.ReadLine();
        }

        private void RunProcess(int processNumber, int processLoopCondition)
        {
            Console.WriteLine($"\nControl is in process {processNumber}");
            Console.WriteLine($"Process {processNumber} has started.");
            Console.WriteLine($"Process {processNumber} is running...");

            for (int i = 0; i < processLoopCondition; i++)
            {
                //just loop
            }

            Console.WriteLine($"Process {processNumber} is complete!");
            Console.WriteLine("Control is back to main method...");
        }

        private async Task PerformBackgroundOperation()
        {
            Console.WriteLine("Control is in the process performing background operations...");
            Console.WriteLine("The process performing background operations has started.");
            Console.WriteLine("The process performing background operations is running...");

            await Task.Run(() =>
            {
                Console.WriteLine("The background process has reached the await region...");
                Thread.Sleep(5000);
                Console.WriteLine("The background process has finished the await region...");
            });

            Console.WriteLine("The background process is complete!");
            Console.WriteLine("Control is in the process performing background operations AGAIN...");

            for(int i = 0; i<10; i++)
            {
                Console.WriteLine($"Performing additional operation #{i+1}");
            }

            Console.WriteLine("The additional operations from the background process are complete!");
        }
    }
}
