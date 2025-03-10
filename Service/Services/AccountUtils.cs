using BusinessObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountUtils
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountUtils(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Account GetCurrentAccount()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                // Lấy thông tin từ claim
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userName = user.FindFirst(ClaimTypes.Name)?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    return new Account
                    {
                        Id = int.Parse(userId),
                        FullName = userName
                    };
                }
            }

            throw new Exception("Please login");
        }
    }
}
