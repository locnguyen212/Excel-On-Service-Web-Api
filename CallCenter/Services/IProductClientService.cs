using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IProductClientService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByClientId(int id);
        public Task<dynamic> FindByProductId(int id);
        public Task<dynamic> FindByCustomerId(int id);
        public Task<bool> Create(ProductClient productClient);
        public Task<bool> Delete(int id);
        public Task<bool> Update(ProductClient productClient);
    }
}
