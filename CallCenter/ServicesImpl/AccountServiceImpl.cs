using CallCenter.Models;
using CallCenter.Services;
using CallCenter.Utils.UtilModels;
using Microsoft.EntityFrameworkCore;

namespace CallCenter.ServicesImpl
{
    public class AccountServiceImpl : IAccountService
    {
        private DatabaseContext _dbContext;

        public AccountServiceImpl(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Account account)
        {
            try
            {
                account.CreatedAt = DateTime.Now;
                _dbContext.Accounts.Add(account);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Account account)
        {
            try
            {
                account.UpdatedAt = DateTime.Now;
                _dbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var account = await _dbContext.Accounts.Where(e => e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
                if (account != null && account.Id != 1)
                {
                    var orders = await _dbContext.Orders.Where(e => e.DeletedAt == null && (e.CustomerId == account.Id || e.StaffId == account.Id)).ToListAsync();
                    var orderClients = account.OrderClients.Where(e => e.DeletedAt == null).ToList();
                    var complaints = account.Complaints.Where(e => e.DeletedAt == null).ToList();
                    var clients = account.Clients.Where(e => e.DeletedAt == null).ToList();
                    var products = account.Products.Where(e => e.DeletedAt == null).ToList();

                    if (orderClients.Count != 0 || complaints.Count != 0 || clients.Count != 0 || products.Count != 0 || orders.Count != 0 )
                    {
                        return false;
                    }

                    account.DeletedAt = DateTime.Now;
                    _dbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return await _dbContext.Accounts.Where(e => e.DeletedAt == null).Select(e => new
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Email = e.Email,
                Phone = e.Phone,
                Role = e.Role,
                Status = e.Status,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.DepartmentId != null? e.Department.Name : null
            }).ToListAsync();
        }

        public async Task<dynamic> FindById(int id)
        {
            return await _dbContext.Accounts.Where(e => e.DeletedAt == null && e.Id == id).Select(e => new
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Email = e.Email,
                Phone = e.Phone,
                Role = e.Role,
                Status = e.Status,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<dynamic> FindByRole(string role)
        {
            return await _dbContext.Accounts.Where(e => e.DeletedAt == null && e.Role.Equals(role.ToLower())).Select(e => new
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Email = e.Email,
                Phone = e.Phone,
                Role = e.Role,
                Status = e.Status,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name
            }).ToListAsync();
        }

        public async Task<dynamic> FindByDepartmentId(int id)
        {
            return await _dbContext.Accounts.Where(e => e.DeletedAt == null && e.DepartmentId == id).Select(e => new
            {
                Id = e.Id,
                Username = e.Username,
                Password = e.Password,
                Email = e.Email,
                Phone = e.Phone,
                Role = e.Role,
                Status = e.Status,
                CreatedAt = e.CreatedAt.HasValue ? e.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                UpdatedAt = e.UpdatedAt.HasValue ? e.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"):null,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name
            }).ToListAsync();
        }

        public async Task<Account> FindByIdController(int id)
        {
            return await _dbContext.Accounts.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var account = await _dbContext.Accounts.Where(e => e.Email.ToLower().Equals(email.ToLower())).FirstOrDefaultAsync();
            if(account == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Login(LoginModel login)
        {
            var account = await _dbContext.Accounts.Where(e => e.Email.Equals(login.Email) && e.DeletedAt == null).FirstOrDefaultAsync();
            if(account != null)
            {
                return BCrypt.Net.BCrypt.Verify(login.Password, account.Password);
            }
            return false;
        }

        public async Task<Account> FindByEmailController(string email)
        {
            return await _dbContext.Accounts.Where(e => e.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public DateTime? getCreatedAt(int id)
        {
            return _dbContext.Accounts.AsNoTracking().Where(e => e.Id == id).FirstOrDefault().CreatedAt;
        }

        public bool TokenCheck(string token)
        {
            return  _dbContext.Accounts.Any(e => e.DeletedAt == null && e.Token.Equals(token));
        }

        public bool ResetPasswordTokenCheck(string token)
        {
            return _dbContext.Accounts.Any(e => e.DeletedAt == null && e.ResetPasswordToken.Equals(token));
        }

        public bool RefreshTokenCheck(string token)
        {
            return  _dbContext.Accounts.Any(e => e.DeletedAt == null && e.RefreshToken.Equals(token));
        }
    }
}
