using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class NullableTypes
    {
        public void Run()
        {
            List<int> myList = null;
            int? count = 2;
            count = myList?.Count;
            Console.WriteLine(count.ToString());
        }
    }
}
