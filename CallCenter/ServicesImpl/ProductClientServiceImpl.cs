using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class ProductClientServiceImpl : IProductClientService
    {
        private DatabaseContext _dbContext;
        public ProductClientServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(ProductClient productClient)
        {
            try
            {
                productClient.CreatedAt = DateTime.Now;
                _dbContext.ProductClients.Add(productClient);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(ProductClient productClient)
        {
            try
            {
                productClient.UpdatedAt = DateTime.Now;
                _dbContext.Entry(productClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var productClient = _dbContext.ProductClients.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefault();
                if (productClient != null)
                {
                    productClient.DeletedAt = DateTime.Now;
                    _dbContext.Entry(productClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.ProductClients.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                ClientId = e.ClientId,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.Phone,
                ClientEmail = e.Client.Email,
                ClientDescription = e.Client.Description,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.ProductClients.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                ClientId = e.ClientId,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.Phone,
                ClientEmail = e.Client.Email,
                ClientDescription = e.Client.Description,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByClientId(int id)
        {
            return await _dbContext.ProductClients.Where(e => e.DeletedAt == null && e.ClientId == id).Select(e => new
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                ClientId = e.ClientId,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.Phone,
                ClientEmail = e.Client.Email,
                ClientDescription = e.Client.Description,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByProductId(int id)
        {
            return await _dbContext.ProductClients.Where(e => e.DeletedAt == null && e.ProductId == id).Select(e => new
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                ClientId = e.ClientId,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.Phone,
                ClientEmail = e.Client.Email,
                ClientDescription = e.Client.Description,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId
            }).ToListAsync();
        }

        public async Task<dynamic> FindByCustomerId(int id)
        {
            return await _dbContext.ProductClients.Where(e => e.DeletedAt == null && e.Product.Customer.Id == id).Select(e => new
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                ClientId = e.ClientId,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.Phone,
                ClientEmail = e.Client.Email,
                ClientDescription = e.Client.Description,
                ProductId = e.ProductId,
                ProductName = e.Product.Name,
                CustomerId = e.Product.CustomerId
            }).ToListAsync();
        }
    }
}
