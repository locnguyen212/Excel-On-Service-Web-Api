using CallCenter.Models;
using CallCenter.Services;
using CallCenter.Utils.Helpers;
using CallCenter.Utils.UtilModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace CallCenter.Controllers
{
    [Route("api/account")]
    //[Authorize(Roles = "super admin, admin 1, admin 2")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private ISendEmailService _sendEmailService;
        private IConfiguration _configuration;
        public AccountController(IAccountService accountService, ISendEmailService sendEmailService, IConfiguration configuration)
        {
            _accountService = accountService;
            _sendEmailService = sendEmailService;
            _configuration = configuration;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {               
                //Console.WriteLine("ID: " + Request.Headers["id"]);
                return Ok(await _accountService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-department/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByDepartment(int id)
        {
            try
            {
                return Ok(await _accountService.FindByDepartmentId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                return Ok(await _accountService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody]Account account)
        {
            try
            {
                if(account == null)
                {
                    return BadRequest();
                }
                else
                {
                    if (account.Password != null)
                    {
                        if (account.Password.Length < 5 || account.Password.Length > 20)
                        {
                            ModelState.AddModelError("Password", "The field Password must be a string with a minimum length of 5 and a maximum length of 20.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "The field Password is required.");
                    }
                    
                    
                }

                


                if (ModelState.IsValid)
                {
                    var acc = account;

                    if (await _accountService.IsEmailExist(acc.Email))
                    {
                        return BadRequest("Email is already existed.");
                    }

                    acc.Status = false;
                    acc.Token = CreateToken("email");
                    acc.Password = BCrypt.Net.BCrypt.HashPassword(acc.Password);
                    var result = await _accountService.Create(acc);



                    if (result)
                    {
                        var emailModel = new EmailModel()
                        {
                            Content = EmailBody.EmailConfirmStringBody(acc.Email, acc.Token),
                            Subject = "Mail confirm Api",
                            To = acc.Email
                        };
                        _sendEmailService.SendEmail(emailModel);

                        return Ok(new
                        {
                            Result = result
                        });
                    }


                }
                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        //[Authorize(Roles = "super admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = await _accountService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Authorize(Roles = "super admin, admin 1, admin 2, customer")]
        public async Task<IActionResult> Update([FromBody] Account account)
        {
            try
            {
                if (account == null || account.Id == 0)
                {
                    return BadRequest();
                }

                if (account.Password != null)
                {
                    if (account.Password.Length < 5 || account.Password.Length > 20)
                    {
                        ModelState.AddModelError("Password", "The field Password must be a string with a minimum length of 5 and a maximum length of 20.");
                    }
                }

                if (ModelState.IsValid)
                {
                    var baseAcc = await _accountService.FindByIdController(account.Id);

                    if (account.Password != null)
                    {
                        account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                    }
                    else
                    {
                        account.Password = baseAcc.Password;
                    }

                    return Ok(new
                    {
                        Result = await _accountService.Update(account)
                    });
                }
                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("mail-confirm"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> MailConfirm([FromBody] EmailConfirmModel emailConfirmModel)
        {
            try
            {
                //FE tạo tk => BE trả MailConfirmToken => FE dùng MailConfirmToken + email để tạo mail và gửi active account mail => dẫn tới 1 trang FE khác => trang này call MailConfirm trên BE để active
                var account = await _accountService.FindByEmailController(emailConfirmModel.Email);              
                if (account != null && account.Status != true)
                {
                    if (account.Token.Equals(emailConfirmModel.Token))
                    {
                        account.Status = true;
                        account.Token = null;
                        return Ok(new
                        {
                            result = await _accountService.Update(account)
                        });
                    }
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("login"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                if (await _accountService.Login(login))
                {
                    var account = await _accountService.FindByEmailController(login.Email);
                    if (account.Status == true)
                    {
                        account.Token = CreateJwt(account);
                        account.RefreshToken = CreateToken("refresh");
                        account.RefreshTokenExpireTime = DateTime.Now;
                        var result = await _accountService.Update(account);
                        return Ok(new
                        {
                            Result = result,
                            Id = account.Id,
                            Token = account.Token,
                            RefreshToken = account.RefreshToken
                        });
                    }

                }
                return BadRequest("Incorrect login information");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("refresh"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Refresh([FromBody] TokenModel tokenModel)
        {
            try
            {
                if(tokenModel == null)
                {
                    return BadRequest();
                }
                string token = tokenModel.Token;
                string refreshToken = tokenModel.RefreshToken;
                var principal = GetPrincipalFromExpiredToken(token);
                var email = principal.FindFirst(ClaimTypes.Email).Value;

                var account = await _accountService.FindByEmailController(email);

                if (account == null || account.RefreshToken != refreshToken || account.RefreshTokenExpireTime.Value.AddDays(1) < DateTime.Now)
                {
                    return BadRequest();
                }

                var newToken = CreateJwt(account);
                var newRefreshToken = CreateToken("refresh");

                account.Token = newToken;
                account.RefreshToken = newRefreshToken;
                account.RefreshTokenExpireTime = DateTime.Now;

                return Ok(new
                {
                    Result = await _accountService.Update(account),
                    Token = newToken,
                    refreshToken = newRefreshToken
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("change-password")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //[Authorize(Roles = "super admin, admin 1, admin 2, customer")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = await _accountService.FindByEmailController(changePassword.Email);
                    if (account != null)
                    {
                        account.Password = BCrypt.Net.BCrypt.HashPassword(changePassword.Password);
                        return Ok(new
                        {
                            Result = await _accountService.Update(account)
                        });
                    }
                }

                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("forget-password/{email}"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            try
            {
                var account = await _accountService.FindByEmailController(email);
                if (account != null && account.DeletedAt == null && account.Status == true)
                {
                    account.ResetPasswordToken = CreateToken("password");
                    account.RefreshPasswordTime = DateTime.Now;


                    var emailModel = new EmailModel()
                    {
                        Content = EmailBody.EmailStringBody(email, account.ResetPasswordToken),
                        Subject = "Reset Password Api",
                        To = email
                    };
                    _sendEmailService.SendEmail(emailModel);
                    return Ok(new
                    {
                        Result = await _accountService.Update(account),
                        Message = "Email Sent!"
                    });
                }
                return BadRequest("Email does not exist");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("reset-password"), AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = await _accountService.FindByEmailController(resetPassword.Email);
                    if (account != null && account.DeletedAt == null && account.ResetPasswordToken.Equals(resetPassword.ResetPasswordToken))
                    {
                        if (account.RefreshPasswordTime.Value.AddDays(1) > DateTime.Now)
                        {
                            account.Password = BCrypt.Net.BCrypt.HashPassword(resetPassword.Password);
                            account.ResetPasswordToken = null;
                            account.RefreshPasswordTime = null;
                            return Ok(new
                            {
                                Result = await _accountService.Update(account)
                            });
                        }

                        return BadRequest("Token has expired");
                    }

                }
                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }

        private string DecodeUrlString(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }

        private string CreateToken(string type)
        {
            var tokenByte = RandomNumberGenerator.GetBytes(64);
            var token = Convert.ToBase64String(tokenByte);

            if (type.Equals("refresh"))
            {
                var refreshTokenCheck = _accountService.RefreshTokenCheck(token);
                if (refreshTokenCheck)
                {
                    return CreateToken(type);
                }
            }
            else if (type.Equals("email"))
            {
                var emailTokenCheck = _accountService.TokenCheck(token);
                if (emailTokenCheck)
                {
                    return CreateToken(type);
                }
            }
            else if (type.Equals("password"))
            {
                var passwordTokenCheck = _accountService.ResetPasswordTokenCheck(token);
                if (passwordTokenCheck)
                {
                    return CreateToken(type);
                }
            }


            return token;

        }

        //tạo login token
        private string CreateJwt(Account account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            //tạo key, secret
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            //tạo payload
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim(ClaimTypes.Name, account.Username)
            });

            //tạo signature
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            //tạo Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            //tạo token
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
    }
}
