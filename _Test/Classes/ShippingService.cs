using Fawry_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class ShippingService
    {
        public static void Ship(List<IShippable> items)
        {
            Console.WriteLine("** Shipment notice **");

            var grouped = items
                .GroupBy(i => new { Name = i.GetName(), Weight = i.GetWeight() })
                .Select(g => new
                {
                    g.Key.Name,
                    g.Key.Weight,
                    Count = g.Count()
                });

            double totalWeight = 0;

            foreach (var g in grouped)
            {
                double groupWeight = g.Weight * g.Count;
                totalWeight += groupWeight;
                Console.WriteLine($"{g.Count}x {g.Name} {groupWeight * 1000}g");
            }
            Console.WriteLine($"Total package weight {totalWeight}kg\n");
        }
    }

}
