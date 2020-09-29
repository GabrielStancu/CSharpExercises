using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class DynamicDemo
    {
        public void Run()
        {
            dynamic value = 0;
            Console.WriteLine($"Value is {value}, type is {value.GetType().Name}");

            value = "What am I now?";
            Console.WriteLine($"Value is {value}, type is {value.GetType().Name}");

            value = new SampleClass();
            value.Value = 10;
            Console.WriteLine($"Value is {value.Value}, type is {value.GetType().Name}");
        }
    }

    class SampleClass
    {
        public int Value { get; set; }
    }
}
