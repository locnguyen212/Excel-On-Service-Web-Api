using CallCenter.Models;
using CallCenter.Utils.UtilModels;

namespace CallCenter.Services
{
    public interface IAccountService
    {
        public Task<dynamic> FindAll();
        public Task<dynamic> FindById(int id);
        public Task<dynamic> FindByDepartmentId(int id);
        public Task<dynamic> FindByRole(string role);
        public Task<Account> FindByIdController(int id);
        public Task<Account> FindByEmailController(string email);
        public Task<bool> Create(Account account);
        public Task<bool> Delete(int id);
        public Task<bool> Update(Account account);
        public Task<bool> IsEmailExist(string email);
        public Task<bool> Login(LoginModel login);
        public bool TokenCheck(string token);
        public bool RefreshTokenCheck(string token);
        public bool ResetPasswordTokenCheck(string token);
        public DateTime? getCreatedAt(int id);
    }
}
