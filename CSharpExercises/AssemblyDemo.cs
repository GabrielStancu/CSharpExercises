using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CSharpExercises
{
    class AssemblyDemo
    {
        public void Run()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            AssemblyName assemblyName = assembly.GetName();

            Console.WriteLine(assemblyName.FullName);

            assemblyName.Version = new Version("3.0.1.2");
            Console.WriteLine(assemblyName.Version);

        }
    }
}
