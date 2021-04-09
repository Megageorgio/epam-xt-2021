using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime
{
    public class Pizzeria
    {
        public IList<Pizza> Menu { get; }
        private ICollection<Order> Orders { get; }

        public Pizzeria(IEnumerable<Pizza> menu)
        {
            Menu = menu.ToList();
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void PrepareAllOrders()
        {
            foreach (var order in Orders)
            {
                order.OnReady();
            }

            Orders.Clear();
        }
    }
}