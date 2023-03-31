using CallCenter.Models;

namespace CallCenter.Services
{
    public interface IComplaintService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByStaffId(int id);
        public Task<dynamic> FindByOrderId(int id);
        public Task<bool> Create(Complaint complaint);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Complaint complaint);
    }
}
