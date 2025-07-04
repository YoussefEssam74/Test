using _Test.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Fawry_Test.Classes;
class Program
{
    static void Main()
    {
        #region ex1
        var cheese = new ExpirableShippableProduct("Cheese", 100, 5, DateTime.Now.AddDays(5), 0.2);
        var biscuits = new ExpirableShippableProduct("Biscuits", 150, 2, DateTime.Now.AddDays(2), 0.7);
        var tv = new ShippableProduct("TV", 4000, 3, 5);
        var scratchCard = new NonShippableProduct("Mobile Scratch Card", 50, 10);

        var customer = new Customer("Youssef", 1000);

        var cart = new Cart();
        cart.Add(cheese, 2);
        cart.Add(biscuits, 1);

        try
        {
            CheckoutService.Checkout(customer, cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        } 
        #endregion


    }
}
