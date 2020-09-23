using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class Tuples
    {
        public void Run()
        {
            Tuple<string, string, int> oldTuple = GetOldTuple();
            Console.WriteLine($"{oldTuple.Item1} {oldTuple.Item2} {oldTuple.Item3}");

            //Unnamed Tuple 
            var newUnnamedTuple = GetNewUnnamedTuple();
            Console.WriteLine($"{newUnnamedTuple.Item1} {newUnnamedTuple.Item2} {newUnnamedTuple.Item3}");

            var (FirstNameV1, LastNameV1, AgeV1) = GetNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV1} {LastNameV1} {AgeV1}");

            (var FirstNameV2, var LastNameV2, var AgeV2) = GetNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV2} {LastNameV2} {AgeV2}");

            (string FirstNameV3, string LastNameV3, int AgeV3) = GetNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV3} {LastNameV3} {AgeV3}");

            //Named tuples
            var (FirstNameV4, LastNameV4, AgeV4) = GetNewNamedTuple();
            Console.WriteLine($"{FirstNameV4} {LastNameV4} {AgeV4}");

            (string FirstNameV5, string LastNameV5, int AgeV5) = GetNewNamedTuple();
            Console.WriteLine($"{FirstNameV5} {LastNameV5} {AgeV5}");

            var newNamedTuple = GetNewNamedTuple();
            Console.WriteLine($"{newNamedTuple.FirstName} {newNamedTuple.LastName} {newNamedTuple.Age}");
        }

        private (string, string, int) GetNewUnnamedTuple()
        {
            return ("Mark", "Wilson", 30);
        }

        private (string FirstName, string LastName, int Age) GetNewNamedTuple()
        {
            return ("Mark", "Wilson", 30);
        }  

        private Tuple<string, string, int> GetOldTuple()
        {
            return Tuple.Create("Mark", "Wilson", 30);
        }
    }
}
