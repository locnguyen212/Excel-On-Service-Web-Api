using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IServiceService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<bool> Create(Service service);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Service service);
    }
}
