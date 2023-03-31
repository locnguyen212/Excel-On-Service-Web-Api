using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IOrderClientDetailService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByOrderClientId(int id);
        public Task<dynamic> FindByProductId(int id);
        public Task<dynamic> FindByCustomerId(int id);
        public Task<bool> Create(OrderClientDetail orderClientDetail);
        public Task<bool> Delete(int id);
        public Task<bool> Update(OrderClientDetail orderClientDetail);
    }
}
