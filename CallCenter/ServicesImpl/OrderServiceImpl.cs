using CallCenter.Models;
using CallCenter.Services;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class OrderServiceImpl : IOrderService
    {
        private DatabaseContext _dbContext;
        public OrderServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Order order)
        {
            try
            {
                order.CreatedAt = DateTime.Now;
                _dbContext.Orders.Add(order);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Order order)
        {
            try
            {
                order.UpdatedAt = DateTime.Now;
                _dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var order = _dbContext.Orders.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefault();
                if (order != null)
                {
                    var orderClients = order.OrderClients.Where(e => e.DeletedAt == null).ToList();
                    var complaints = order.Complaints.Where(e => e.DeletedAt == null).ToList();

                    if (orderClients.Count == 0 && complaints.Count == 0)
                    {
                        order.DeletedAt = DateTime.Now;
                        _dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.Orders.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            //var a = await _dbContext.Orders.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
            //Console.WriteLine(a);
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByStaff(int id)
        {
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.StaffId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).ToListAsync();
        }

        public async Task<dynamic> FindByCustomer(int id)
        {
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.CustomerId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).ToListAsync();
        }

        public async Task<dynamic> FindByService(int id)
        {
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.ServiceId == id).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,               
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).ToListAsync();
        }

        public async Task<dynamic> FindStaffNull()
        {
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.StaffId == null).Select(e => new
            {
                Id = e.Id,
                Description = e.Description,                
                TotalPrice = e.TotalPrice,               
                Status = e.Status,
                Duration = e.Duration,
                Invoice = e.Invoice,
                StartedAt = e.StartedAt.HasValue ? e.StartedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-ddTHH:mm:ss"):null,
                StaffId = e.StaffId,
                StaffName = e.Staff.Username,
                CustomerId = e.CustomerId,
                CustomerName = e.Customer.Username,
                ServiceId = e.ServiceId,
                ServiceName = e.Service.Name
            }).ToListAsync();
        }

        public async Task<Order> FindOrderController(int id)
        {
            return await _dbContext.Orders.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> FindOrdersControllerCustom()
        {
            return await _dbContext.Orders.Where(e => e.DeletedAt == null && e.Status == true).ToListAsync();
        }
    }
}
