using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class DepartmentServiceImpl : IDepartmentService
    {
        private DatabaseContext _dbContext;
        public DepartmentServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Department department)
        {
            try
            {
                department.CreatedAt = DateTime.Now;
                _dbContext.Departments.Add(department);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Department department)
        {
            try
            {
                department.UpdatedAt = DateTime.Now;
                _dbContext.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var department = await _dbContext.Departments.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (department != null)
                {
                    var accounts = department.Accounts.Where(e => e.DeletedAt == null).ToList();
                    if (accounts.Count == 0)
                    {
                        department.DeletedAt = DateTime.Now;
                        _dbContext.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        return await _dbContext.SaveChangesAsync() > 0;
                    }
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
            return await _dbContext.Departments.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            //var a = await _dbContext.Departments.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
            //Console.WriteLine("count: " + a.Accounts.Count);          
            return await _dbContext.Departments.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
            }).FirstOrDefaultAsync();
        }
    }
}
