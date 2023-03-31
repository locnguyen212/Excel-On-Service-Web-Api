using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class ServiceServiceImpl : IServiceService
    {
        private DatabaseContext _dbContext;
        public ServiceServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Service service)
        {
            try
            {
                service.CreatedAt = DateTime.Now;
                _dbContext.Services.Add(service);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Service service)
        {
            try
            {
                service.UpdatedAt = DateTime.Now;
                _dbContext.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var service = _dbContext.Services.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefault();
                if (service != null)
                {
                    var orders = service.Orders.Where(e => e.DeletedAt == null).ToList();
                    if (orders.Count == 0)
                    {
                        service.DeletedAt = DateTime.Now;
                        _dbContext.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.Services.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.Services.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
            }).FirstOrDefaultAsync();
        }
    }
}
