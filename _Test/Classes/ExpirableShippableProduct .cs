using Fawry_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class ExpirableShippableProduct : ExpirableProduct, IShippable
    {
        public double Weight { get; }

        public ExpirableShippableProduct(string name, double price, int quantity, DateTime expiryDate, double weight)
            : base(name, price, quantity, expiryDate)
        {
            Weight = weight;
        }

        public override bool RequiresShipping() => true;

        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
