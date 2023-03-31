using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IClientService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByCustomerId(int id);
        public Task<bool> Create(Client client);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Client client);
    }
}
