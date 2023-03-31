using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class ProductServiceImpl : IProductService
    {
        private DatabaseContext _dbContext;
        public ProductServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Product product)
        {
            try
            {
                product.CreatedAt = DateTime.Now;
                _dbContext.Products.Add(product);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                product.UpdatedAt = DateTime.Now;
                _dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var product = _dbContext.Products.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefault();
                if (product != null)
                {
                    var productClients = product.ProductClients.Where(e => e.DeletedAt == null).ToList();
                    if (productClients.Count == 0)
                    {
                        product.DeletedAt = DateTime.Now;
                        _dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.Products.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.Products.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByCustomerId(int id)
        {
            return await _dbContext.Products.Where(e => e.DeletedAt == null && e.CustomerId == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).ToListAsync();
        }
    }
}
