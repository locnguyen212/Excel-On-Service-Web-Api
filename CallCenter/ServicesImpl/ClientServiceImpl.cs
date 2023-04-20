using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class ClientServiceImpl : IClientService
    {
        private DatabaseContext _dbContext;
        public ClientServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Client client)
        {
            try
            {
                client.CreatedAt = DateTime.Now;
                _dbContext.Clients.Add(client);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Client client)
        {
            try
            {
                client.UpdatedAt = DateTime.Now;
                _dbContext.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var client = await _dbContext.Clients.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (client != null)
                {
                    var productClient = client.ProductClients.Where(e => e.DeletedAt == null).ToList();

                    if (productClient.Count == 0)
                    {
                        client.DeletedAt = DateTime.Now;
                        _dbContext.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.Clients.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Email = e.Email,
                Phone = e.Phone,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.Clients.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Email = e.Email,
                Phone = e.Phone,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByCustomerId(int id)
        {
            return await _dbContext.Clients.Where(e => e.DeletedAt == null && e.CustomerId == id).Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Email = e.Email,
                Phone = e.Phone,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username
            }).ToListAsync();
        }
    }
}
