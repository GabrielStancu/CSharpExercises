using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class EventDemo
    {
        Football football;
        
        public void Run()
        {
            football = new Football();
            football.DisplayTeamInfo();
            football.DisplayPlayerInfo();
        }
    }

    //subscriber
    class Football
    {
        private DisplayInformation displayInformation;

        public Football()
        {
            displayInformation = new DisplayInformation();
            displayInformation.DisplayDateAfterEvent += DisplayInformation_DisplayDateAfterEvent;
            displayInformation.DisplayMessageBeforeEvent += DisplayInformation_DisplayMessageBeforeEvent;
        }

        private void DisplayInformation_DisplayMessageBeforeEvent()
        {
            Console.WriteLine("Program is about to display information");
        }

        private void DisplayInformation_DisplayDateAfterEvent()
        {
            Console.WriteLine("Information displayed on " + DateTime.Now.ToShortTimeString());
        }

        public void DisplayTeamInfo()
        {
            displayInformation.DisplayClub("Borussia Dortmund", "Germany");
        }

        public void DisplayPlayerInfo()
        {
            displayInformation.DisplayPlayer("Jadon Sancho", "Borussia Dormund");
        }
    }


    //publisher class
    class DisplayInformation
    {
        public delegate void DisplayDateAfterDelegate();
        public delegate void DisplayMessageBeforeDelegate();
        public event DisplayDateAfterDelegate DisplayDateAfterEvent;
        public event DisplayMessageBeforeDelegate DisplayMessageBeforeEvent;

        public void DisplayClub(string clubName, string country)
        {
            DisplayMessageBeforeEvent();
            Console.WriteLine($"{clubName} from {country}");
            DisplayDateAfterEvent();
            Console.WriteLine();
        }

        public void DisplayPlayer(string playerName, string clubName)
        {
            DisplayMessageBeforeEvent();
            Console.WriteLine($"{playerName} plays for {clubName}");
            DisplayDateAfterEvent();
            Console.WriteLine();
        }
    }
}
