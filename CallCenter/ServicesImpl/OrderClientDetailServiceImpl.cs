using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class OrderClientDetailServiceImpl : IOrderClientDetailService
    {
        private DatabaseContext _dbContext;
        public OrderClientDetailServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(OrderClientDetail orderClientDetail)
        {
            try
            {
                orderClientDetail.CreatedAt = DateTime.Now;
                _dbContext.OrderClientDetails.Add(orderClientDetail);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(OrderClientDetail orderClientDetail)
        {
            try
            {
                orderClientDetail.UpdatedAt = DateTime.Now;
                _dbContext.Entry(orderClientDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var orderClientDetail = await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (orderClientDetail != null)
                {
                    orderClientDetail.DeletedAt = DateTime.Now;
                    _dbContext.Entry(orderClientDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderClientId = e.OrderClientId,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId,
                StaffId = e.OrderClient.StaffId
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderClientId = e.OrderClientId,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId,
                StaffId = e.OrderClient.StaffId
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByOrderClientId(int id)
        {
            return await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null && e.OrderClientId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderClientId = e.OrderClientId,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId,
                StaffId = e.OrderClient.StaffId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByProductId(int id)
        {
            return await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null && e.ProductId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                OrderClientId = e.OrderClientId,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId,
                StaffId = e.OrderClient.StaffId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByCustomerId(int id)
        {
            return await _dbContext.OrderClientDetails.Where(e => e.DeletedAt == null && e.OrderClient.Order.CustomerId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                OrderClientId = e.OrderClientId,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId,
                StaffId = e.OrderClient.StaffId
            }).ToListAsync();
        }
    }
}
