using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Globalization;

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

            Console.WriteLine(assemblyName.CultureName);
            CultureInfo cultureInfo = new CultureInfo("ro-RO");
            assemblyName.CultureInfo = cultureInfo;
            Console.WriteLine(assemblyName.CultureInfo.DisplayName);
            Console.WriteLine(assemblyName.CultureInfo.NativeName);
            Console.WriteLine(assemblyName.CultureInfo.NumberFormat.CurrencySymbol);
            Console.WriteLine(assemblyName.CultureInfo.Calendar);

            RegionInfo regionInfo = new RegionInfo("RO");
            Console.WriteLine(regionInfo.DisplayName);
            Console.WriteLine(regionInfo.NativeName);
            Console.WriteLine(regionInfo.IsMetric);
            Console.WriteLine(regionInfo.CurrencyEnglishName);
            Console.WriteLine(regionInfo.ThreeLetterISORegionName);
            Console.WriteLine(regionInfo.ISOCurrencySymbol);
        }
    }
}
