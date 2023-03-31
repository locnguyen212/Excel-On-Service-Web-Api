using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IProductService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByCustomerId(int id);
        public Task<bool> Create(Product product);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Product product);
    }
}
