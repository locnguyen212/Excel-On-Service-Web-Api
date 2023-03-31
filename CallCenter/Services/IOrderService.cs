using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IOrderService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindStaffNull();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByStaff(int id);
        public Task<dynamic> FindByCustomer(int id);
        public Task<dynamic> FindByService(int id);
        public Task<bool> Create(Order order);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Order order);
        public Task<Order> FindOrderController(int id);
        public Task<List<Order>> FindOrdersControllerCustom();
    }
}
