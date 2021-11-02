using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaStoreAPi.Models;
using ViewModels.DtoClasses;

namespace PizzaStoreAPi.Repositories
{
    public interface IOrderRepository
    {
        public Task AddOrder(OrderDto order);
        public void SaveOrders();
        Task<List<OrderViewModel>> GetAllOrdersAsync();
    }
}