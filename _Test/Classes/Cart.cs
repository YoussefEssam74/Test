using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class Cart
    {
        public List<CartItem> Items { get; } = new();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
                throw new Exception($"Cannot add {quantity} of {product.Name}. Only {product.Quantity} in stock.");
            Items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty() => Items.Count == 0;
    }
}
