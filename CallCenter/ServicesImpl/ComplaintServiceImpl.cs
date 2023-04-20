using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class ComplaintServiceImpl : IComplaintService
    {
        private DatabaseContext _dbContext;
        public ComplaintServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Complaint complaint)
        {
            try
            {
                complaint.CreatedAt = DateTime.Now;
                _dbContext.Complaints.Add(complaint);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Complaint complaint)
        {
            try
            {
                complaint.UpdatedAt = DateTime.Now;
                _dbContext.Entry(complaint).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var complaint = await _dbContext.Complaints.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (complaint != null)
                { 
                    complaint.DeletedAt = DateTime.Now;
                    _dbContext.Entry(complaint).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;            
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<dynamic> FindAll()
        {
            return await _dbContext.Complaints.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,                
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.Complaints.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByStaffId(int id)
        {
            return await _dbContext.Complaints.Where(e => e.DeletedAt == null && e.StaffId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,              
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username
            }).ToListAsync();
        }

        public async Task<dynamic> FindByOrderId(int id)
        {
            return await _dbContext.Complaints.Where(e => e.DeletedAt == null && e.OrderId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username
            }).ToListAsync();
        }
    }
}
