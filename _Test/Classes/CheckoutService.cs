using Fawry_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test.Classes
{
    class CheckoutService
    {
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new Exception("Cart is empty.");

            double subtotal = 0;
            List<IShippable> shippableItems = new();

            foreach (var item in cart.Items)
            {
                var product = item.Product;

                if (product.IsExpired())
                    throw new Exception($"Product {product.Name} is expired.");

                if (product.Quantity < item.Quantity)
                    throw new Exception($"Not enough stock for {product.Name}.");

                subtotal += product.Price * item.Quantity;

                if (product.RequiresShipping() && product is IShippable shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                        shippableItems.Add(shippable);
                }
            }

            double totalWeight = shippableItems.Sum(x => x.GetWeight()); // ✅ used for shipment display
            double shipping = 30; // ✅ flat rate shipping as required

            double total = subtotal + shipping;

            if (customer.Balance < total)
                throw new Exception("Insufficient balance.");

            foreach (var item in cart.Items)
                item.Product.Quantity -= item.Quantity;

            customer.Balance -= total;

            if (shippableItems.Count > 0)
                ShippingService.Ship(shippableItems);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Product.Price * item.Quantity}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine($"Shipping {shipping}");
            Console.WriteLine($"Amount {total}");
           
        }
    }
}
