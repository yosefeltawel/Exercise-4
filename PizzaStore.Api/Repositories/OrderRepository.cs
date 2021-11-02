using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Data.EntityClasses;
using PizzaStore.Data.HelperClasses;
using PizzaStore.Data.Linq;
using PizzaStoreAPi.Models;
using SD.LLBLGen.Pro.LinqSupportClasses;
using ViewModels.DtoClasses;
using ViewModels.Persistence;

namespace PizzaStoreAPi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task AddOrder(OrderDto order)
        {
            var adapter = new DataAccessAdapter();
            try
            {
                await adapter.StartTransactionAsync(IsolationLevel.ReadUncommitted, nameof(AddOrder));
                var newOrder = new OrderEntity()
                {
                    Note = order.Note,
                    IsNew = true
                };

                await adapter.SaveEntityAsync(newOrder, true);

                var orderPizzas = order.Pizzas
                    .ConvertAll(p => new OrderPizzaEntity()
                    {
                        OrderId = newOrder.Id,
                        PizzaId = p.Id
                    });

                await adapter.SaveEntityCollectionAsync(new EntityCollection<OrderPizzaEntity>(orderPizzas), true,
                    false);

                var pizzaWithTopping = orderPizzas.SelectMany((p, idx) =>
                {
                    var topping = order.Pizzas[idx].ToppingList;

                    return topping
                        .ConvertAll(t => new PizzaWithToppingEntity()
                        {
                            OrderPizzaId = p.Id,
                            ToppingId = t
                        });
                });

                await adapter.SaveEntityCollectionAsync(
                    new EntityCollection<PizzaWithToppingEntity>(pizzaWithTopping));
                adapter.Commit();
            }
            catch (Exception)
            {
                adapter.Rollback();
            }
        }

        public void SaveOrders()
        {
            Console.WriteLine("Orders dispose");
        }

        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var adapter = new DataAccessAdapter();
            var meta = new LinqMetaData(adapter);
            var orders = await meta.Order.ProjectToOrderViewModel().ToListAsync();
            return orders;
        }
    }
}