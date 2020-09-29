using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CSharpExercises
{
    class ProcessDemo
    {
        public void Run()
        {
            Process.Start("Notepad.exe");
            //Process.Start("devenv.exe");
            //Process.Start("https://www.google.com/");

            Process[] notepadProcesses = Process.GetProcessesByName("notepad");
            foreach (var proc in notepadProcesses)
            {
                proc.Kill();
            }

            WriteAndAccessFile();
        }

        private void WriteAndAccessFile()
        {
            string path = @"D:\C# Projects\CSharpExercises\CSharpExercises\myFile.txt";
            File.WriteAllText(path, "The message I am going to need later...");
            Process.Start(path);
            //read the file...
        }
    }
}
