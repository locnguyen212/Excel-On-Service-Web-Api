using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IOrderClientService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByStaffId(int id);
        public Task<dynamic> FindByOrderId(int id);
        public Task<dynamic> FindByCustomerId(int id);
        public Task<bool> Create(OrderClient orderClient);
        public Task<bool> Delete(int id);
        public Task<bool> Update(OrderClient orderClient);
    }
}
