using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace T06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> signedPeople = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ").ToArray();

            while (input[0] != "end")
            {
                string course = input[0];
                string person = input[1];

                if (!signedPeople.ContainsKey(course))
                {
                    signedPeople.Add(course, new List<string>());
                    signedPeople[course].Add(person);
                }
                else
                {
                    signedPeople[course].Add(person);
                }
                input = Console.ReadLine().Split(" : ").ToArray();
            }

            signedPeople = signedPeople.OrderByDescending(x => x.Value.Count)
                .ToDictionary(signedPeople => signedPeople.Key, signedPeople => signedPeople.Value);


            foreach (var courses in signedPeople)
            {
                Console.WriteLine($"{courses.Key}: {courses.Value.Count}");
                Console.Write("-- ");
                Console.WriteLine(string.Join("\n-- ", courses.Value.OrderBy(value => value)));
            }
        }
    }
}
