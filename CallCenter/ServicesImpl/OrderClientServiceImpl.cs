using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class OrderClientServiceImpl : IOrderClientService
    {
        private DatabaseContext _dbContext;
        public OrderClientServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(OrderClient orderClient)
        {
            try
            {
                orderClient.CreatedAt = DateTime.Now;
                _dbContext.OrderClients.Add(orderClient);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(OrderClient orderClient)
        {
            try
            {
                orderClient.UpdatedAt = DateTime.Now;
                _dbContext.Entry(orderClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var orderClient = await _dbContext.OrderClients.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (orderClient != null)
                {
                    var orderClientDetail = orderClient.OrderClientDetails.Where(e => e.DeletedAt == null).ToList();
                    if (orderClientDetail.Count == 0)
                    {
                        orderClient.DeletedAt = DateTime.Now;
                        _dbContext.Entry(orderClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.OrderClients.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,                
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.Order.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.OrderClients.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.Order.CustomerId
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByStaffId(int id)
        {
            return await _dbContext.OrderClients.Where(e => e.DeletedAt == null && e.StaffId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,              
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.Order.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByOrderId(int id)
        {
            return await _dbContext.OrderClients.Where(e => e.DeletedAt == null && e.OrderId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.Order.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByCustomerId(int id)
        {
            return await _dbContext.OrderClients.Where(e => e.DeletedAt == null && e.Order.CustomerId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                OrderId = e.OrderId,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.Order.CustomerId
            }).ToListAsync();
        }
    }
}
