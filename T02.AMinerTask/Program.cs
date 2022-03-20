using System;
using System.Collections.Generic;

namespace T02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputMaterial = String.Empty;
            int inputQuantity = 0;

            Dictionary<string, int> resources = new Dictionary<string, int>();


            while (true)
            {
                inputMaterial = Console.ReadLine();
                if (inputMaterial == "stop") break;
                inputQuantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(inputMaterial))
                {
                    resources.Add(inputMaterial, inputQuantity);
                }
                else
                {
                    resources[inputMaterial] += inputQuantity;
                }
            }

            foreach (var material in resources)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
