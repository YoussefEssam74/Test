using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class NonShippableProduct : Product
    {
        public NonShippableProduct(string name, double price, int quantity)
            : base(name, price, quantity) { }
    }

}
