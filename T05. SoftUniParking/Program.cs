using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registry = new Dictionary<string, string>();

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] action = Console.ReadLine().Split().ToArray();
                string signinout = action[0];
                string username = action[1];

                if (signinout == "register")
                {
                    string licensePlate = action[2];

                    if (!registry.ContainsKey(username))
                    {
                        registry.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                }
                else if(signinout == "unregister")
                {
                    if (!registry.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        registry.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var car in registry)
            {
             Console.WriteLine($"{car.Key} => {car.Value}");   
            }

        }
    }
}
