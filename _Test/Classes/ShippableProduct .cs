using Fawry_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class ShippableProduct : Product, IShippable
    {
        public double Weight { get; }

        public ShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public override bool RequiresShipping() => true;

        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
