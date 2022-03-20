using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> productInformation = new Dictionary<string, List<double>>();

            string[] productInput = Console.ReadLine().Split().ToArray();

            while (productInput[0] != "buy")
            {
                string productName = productInput[0];
                double productPrice = double.Parse(productInput[1]);
                double productQuantity = double.Parse(productInput[2]);

                if (!productInformation.ContainsKey(productName))
                {
                    productInformation.Add(productName, new List<double>());
                    productInformation[productName].Add(productPrice);
                    productInformation[productName].Add(productQuantity);
                }
                else
                {
                    if (productInformation[productName][0] != productPrice)
                    {
                        productInformation[productName][0] = productPrice;
                    }
                    productInformation[productName][1] += productQuantity;
                }
                productInput = Console.ReadLine().Split().ToArray();
            }

            foreach (var item in productInformation)
            {
                double price = item.Value[0];
                double quantity = item.Value[1];
                double totalPrice = price * quantity;
                
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }

        }
    }
}
