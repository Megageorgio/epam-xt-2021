using System;
using System.Collections.Generic;

namespace PizzaTime
{
    public record Order(IEnumerable<SubOrder> SubOrders)
    {
        public event Action<Order> Ready;

        public void OnReady()
        {
            Ready?.Invoke(this);
        }
    }
}