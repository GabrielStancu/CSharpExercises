using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSharpExercises
{
    class PatternMatchingDemo
    {
        public void Run()
        {
            Dog max = new Dog();
            Lion simba = new Lion();
            Snake solidSnake = new Snake();
            Lizard liz = new Lizard();

            //AnimalSound(max);
            //AnimalSound(simba);
            //AnimalSound(solidSnake);
            //AnimalSound(liz);

            //AnimalSoundWithSwitch(max);
            //AnimalSoundWithSwitch(simba);
            //AnimalSoundWithSwitch(solidSnake);
            //AnimalSoundWithSwitch(liz);

            AnimalSoundWithSwitchAndWhen(max);
            max.DogName = "Max";
            AnimalSoundWithSwitchAndWhen(max);
        }

        //using IS
        public void AnimalSound (object animal)
        {
            if(animal is Dog)
            {
                Console.WriteLine("Woof");
            }
            else if (animal is Cat)
            {
                Console.WriteLine("Meow");
            }
            else if (animal is Lion)
            {
                Console.WriteLine("Roar");
            }
            else if (animal is Duck)
            {
                Console.WriteLine("Quack");
            }
            else if (animal is Snake)
            {
                Console.WriteLine("Snakes are actually mute :O");
            }
            else
            {
                Console.WriteLine("Unknown animal...");
            }
        }

        //using SWITCH 
        public void AnimalSoundWithSwitch(object animal)
        {
            switch(animal)
            {
                case Dog d:
                    Console.WriteLine("Woof");
                    break;
                case Cat c:
                    Console.WriteLine("Meow");
                    break;
                case Lion l:
                    Console.WriteLine("Roar");
                    break;
                case Duck d:
                    Console.WriteLine("Quack");
                    break;
                case Snake s:
                    Console.WriteLine("Snakes are actually mute :O");
                    break;
                default:
                    Console.WriteLine("Unknown animal...");
                    break;
            }
        }

        //using SWITCH and THEN
        public void AnimalSoundWithSwitchAndWhen(object animal)
        {
            switch (animal)
            {
                case Dog d when d.DogName == null:
                    Console.WriteLine("Name is not set");
                    break;
                case Dog d:
                    Console.WriteLine($"{d.DogName} says Woof!");
                    break;
                default:
                    Console.WriteLine("Unknown animal...");
                    break;
            }
        }

        private class Dog
        {
            //Woof woof
            public string DogSound { get; set; }
            public string DogName { get; set; }
        }

        private class Cat
        {
            //Meow meow
            public string CatSound { get; set; }
            public string CatName { get; set; }
        }

        private class Lion
        {
            //Roar
            public string LionSound { get; set; }
            public string LionName { get; set; }
        }

        private class Duck
        {
            //Quack
            public string DuckSound { get; set; }
            public string DuckName { get; set; }
        }

        private class Snake
        {
            //Silent
            public string SnakeSound { get; set; }
            public string SnakeName { get; set; }
        }

        private class Lizard
        {
            
        }
    }
}
