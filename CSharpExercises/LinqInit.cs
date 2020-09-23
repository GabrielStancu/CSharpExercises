using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharpExercises
{
    class FamilyMember
    {
        public string Name;
        public int Age;
        public int PlayedSports;
    }
    class LinqInit
    {
        public void Run()
        {
            OrderLists();
        }

        private void OrderLists()
        {
            var people = new List<FamilyMember>()
            {
                new FamilyMember()
                {
                    Name = "Gabi",
                    Age = 21,
                    PlayedSports = 3
                },
                new FamilyMember()
                {
                    Name = "Razvan",
                    Age = 19,
                    PlayedSports = 1
                },
                new FamilyMember()
                {
                    Name = "Andra",
                    Age = 12,
                    PlayedSports = 3
                },
            };
            var orderedPeople = new List<FamilyMember>();

            Console.WriteLine("Using query syntax:");
            orderedPeople = (from person in people
                             orderby person.PlayedSports, person.Age descending
                             select person).ToList();
            orderedPeople.ForEach(p => Console.WriteLine(p.Name));

            Console.WriteLine("Using method syntax:");
            orderedPeople = people.OrderBy(p => p.PlayedSports).ThenByDescending(p => p.Age).ToList();
            orderedPeople.ForEach(p => Console.WriteLine(p.Name));

            Console.WriteLine("Using separate method:");
            SortPeople(people).ForEach(p => Console.WriteLine(p.Name));
        }

        private List<FamilyMember> SortPeople(List<FamilyMember> people)
        {
            var list = people.OrderBy(p => p.PlayedSports).ThenByDescending(p => p.Age).ToList();
            return list;
        }
    }
}
