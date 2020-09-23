using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class RefLocalsAndReturns
    {
        private int[] _numberArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public void Run()
        {
            //Ref locals 
            int arrayElementByValue = _numberArray[5];
            arrayElementByValue = 600;
            Console.WriteLine($"6th element of _number array has value of {_numberArray[5]}");

            ref int arrayElementByRef = ref _numberArray[5];
            arrayElementByRef = 600;
            Console.WriteLine($"6th element of _number array has value of {_numberArray[5]}");

            //Ref returns 
            int byValue = getRefOfIndex(4);
            ref int byRef = ref getRefOfIndex(4);

            byValue = 100;
            Console.WriteLine($"By val: {_numberArray[4]}");

            byRef = 100;
            Console.WriteLine($"By ref: {_numberArray[4]}");
        }

        ref int getRefOfIndex(int index)
        {
            return ref _numberArray[index];
        }
    }
}
