using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class Deconstruction
    {
        public void Run()
        {
            var (myGas, myMileage, myName) = new Car(100, 1000, "Car1");

            Console.WriteLine($"My gas: {myGas}");
            Console.WriteLine($"My mileage: {myMileage}");
            Console.WriteLine($"My name: {myName}");
        }
    }

    class Car
    {
        public int Gas { get; set; }
        public int Mileage { get; set; }

        public string Name { get; set; }

        public Car(int gas, int mileage, string name)
        {
            Gas = gas;
            Mileage = mileage;
            Name = name;
        }

        public void Deconstruct(out int gas, out int mileage, out string name)
        {
            gas = Gas;
            mileage = Mileage;
            name = Name;
        }
    }
}
