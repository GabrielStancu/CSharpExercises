using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class BinaryLiteralsAndDigitSeparators
    {
        public void Run()
        {
            byte binaryNumber = 0b111; //7 in decimal
            Console.WriteLine($"Without converting: {binaryNumber}");
            Console.WriteLine($"With conversion: {Convert.ToInt16(binaryNumber)}");

            long veryLongNr = 100_000_000_000;
            Console.WriteLine(veryLongNr);
        }
    }
}
