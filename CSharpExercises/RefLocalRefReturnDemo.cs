using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CSharpExercises
{
    class RefLocalRefReturnDemo
    {
        public void Run()
        {
            CopyWithoutRef();
            CopyWithRef();

            ref var returnValue = ref ReturnByReference();
            Console.WriteLine(returnValue);
        }

        private void CopyWithoutRef()
        {
            int x1 = 3;
            int x2 = x1;

            x1 = 2;
            Console.WriteLine("Copied without ref:");
            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.WriteLine("-------------------");
        }

        private void CopyWithRef()
        {
            int x1 = 70;
            ref int x2 = ref x1;

            x1 = 20;
            Console.WriteLine("Copied with ref:");
            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.WriteLine("-------------------");
        }

        private ref string ReturnByReference()
        {
            string[] arrayOfNames = { "Andra", "Razvan", "Gabi" };
            return ref arrayOfNames[0];
        }
    }
}
