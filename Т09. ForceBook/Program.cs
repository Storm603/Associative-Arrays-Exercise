using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Т09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> record = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                bool userChecker = false;

                if (input.Contains("|"))
                {
                    string[] inp1 = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string side = inp1[0];
                    string user = inp1[1];

                    if (!record.ContainsKey(side))
                    {
                        record.Add(side, new List<string>());
                    }

                    foreach (var sides in record.Keys)
                    {
                        if (record[sides].Contains(user))
                        {
                            userChecker = true;                  // means it contains the user
                            break;
                        }
                    }

                    if (userChecker == false)                   // if it didnt contain the user
                    {
                        record[side].Add(user);
                    }

                }
                else if (input.Contains("->"))
                {
                    string[] inp2 = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);           // possible missing KEY from INPUT

                    string user = inp2[0];
                    string side = inp2[1];

                    // add KEY here in case of error
                    foreach (var sides in record.Keys)
                    {
                        if (record[sides].Contains(user))
                        {
                            userChecker = true;                  // means it contains the user

                            record[side].Add(user);
                            record[sides].Remove(user);
                            Console.WriteLine($"{user} joins the {side} side!");
                            break;
                        }
                    }

                    if (userChecker == false)
                    {
                        record[side].Add(user);

                        Console.WriteLine($"{user} joins the {side} side!");
                    }

                }
                input = Console.ReadLine();
            }

            foreach (var sideAlignment in record)
            {
                if (sideAlignment.Value.Count == 1) continue;


                record[sideAlignment.Key].OrderBy(x => x).ToList();

            }


            record = record.OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in record)
            {
                if (side.Value.Count == 0) continue;

                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                for (int i = 0; i < side.Value.Count; i++)
                {
                    Console.WriteLine($"! {side.Value[i]}");
                }

            }

        }
    }
}
