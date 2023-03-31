using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IDepartmentService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<bool> Create(Department department);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Department department);
    }
}
