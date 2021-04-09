using System;
using System.Linq;

namespace PizzaTime
{
    record Customer (string Fullname, int Age)
    {
        public void MakeOrder(Pizzeria pizzeria, Order order)
        {
            order.Ready += TakeOrder;
            pizzeria.AddOrder(order);
        }

        public void MakeOrder(Pizzeria pizzeria, params (Pizza Pizza, int Count)[] subOrders) => MakeOrder(pizzeria,
            new Order(subOrders.Select(tuple => new SubOrder(tuple.Pizza, tuple.Count))));

        public void TakeOrder(Order order) => Console.WriteLine(
            $"{Fullname} paid {order.SubOrders.Sum(subOrder => subOrder.Pizza.Price * subOrder.Count)} " +
            $"and got: {string.Join(", ", order.SubOrders.Select(subOrder => $"{subOrder.Count} of {subOrder.Pizza.Name}"))}!"
        );
    }
}