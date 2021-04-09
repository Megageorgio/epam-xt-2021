using System;

namespace PizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer("Korogodov Georgii", 20);
            var customer2 = new Customer("Ivanov Ivan", 23);
            var pizzeria = new Pizzeria(new[]
            {
                new Pizza("Pepperoni Pizza", 100),
                new Pizza("Hawaii Pizza", 150),
                new Pizza("Greek Pizza", 200)
            });
            customer1.MakeOrder(pizzeria, (pizzeria.Menu[0], 5), (pizzeria.Menu[1], 3));
            customer2.MakeOrder(pizzeria, (pizzeria.Menu[2], 1));
            pizzeria.PrepareAllOrders();
        }
    }
}