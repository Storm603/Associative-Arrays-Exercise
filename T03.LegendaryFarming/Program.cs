using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>();
            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            legendaryItems.Add("shards", 0);
            legendaryItems.Add("motes", 0);
            legendaryItems.Add("fragments", 0);

            bool reached = false;

            while (reached != true)
            {
                string[] quantityAndMaterial = Console.ReadLine().ToLower().Split().ToArray();

                for (int i = 0; i < quantityAndMaterial.Length; i += 2)
                {
                    int quantity = int.Parse(quantityAndMaterial[i]);
                    string material = quantityAndMaterial[i + 1];

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            legendaryItems[material] -= 250;
                            switch (material)
                            {
                                case "shards":
                                    Console.WriteLine($"Shadowmourne obtained!");
                                    reached = true;
                                    //sorting(legendaryItems, junkItems);
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    reached = true;
                                    //sorting(legendaryItems, junkItems);
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    reached = true;
                                    //sorting(legendaryItems, junkItems);
                                    break;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems.Add(material, quantity);
                        }
                        else
                        {
                            junkItems[material] += quantity;
                        }
                    }
                }



                //quantityAndMaterial = Console.ReadLine().ToLower().Split().ToArray();
            }
            legendaryItems = legendaryItems.OrderByDescending(legendaryItems => legendaryItems.Value).ThenBy(x => x.Key).ToDictionary(legendaryItems => legendaryItems.Key, legendaryItems => legendaryItems.Value);
            junkItems = junkItems.OrderBy(junkItems => junkItems.Key).ToDictionary(junkItems => junkItems.Key, junkItems => junkItems.Value);

            foreach (var quantity in legendaryItems)
            {
                Console.WriteLine($"{quantity.Key}: {quantity.Value}");
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        //static void sorting(Dictionary<string, int> legendaryItems, Dictionary<string, int> junkItems)
        //{
        //    legendaryItems = legendaryItems.OrderByDescending(legendaryItems => legendaryItems.Value).ThenBy(x => x.Key).ToDictionary(legendaryItems => legendaryItems.Key, legendaryItems => legendaryItems.Value);
        //    junkItems = junkItems.OrderBy(junkItems => junkItems.Key).ToDictionary(junkItems => junkItems.Key, junkItems => junkItems.Value);

        //    foreach (var quantity in legendaryItems)
        //    {
        //        Console.WriteLine($"{quantity.Key}: {quantity.Value}");
        //    }

        //    foreach (var item in junkItems)
        //    {
        //        Console.WriteLine($"{item.Key}: {item.Value}");
        //    }
        //}
    }
}
