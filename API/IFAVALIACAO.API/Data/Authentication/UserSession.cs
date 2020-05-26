using System;
using System.Security.Claims;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using IFAVALIACAO.API.Domain.Parameters;
using Microsoft.AspNetCore.Http;

namespace IFAVALIACAO.API.Data.Authentication
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _accessor;

        public UserSession(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


        public Guid UserId
        {
            get
            {
                if (_accessor.HttpContext == null || !_accessor.HttpContext.User.Identity.IsAuthenticated)
                    return Guid.Empty;
                var idUser = _accessor.HttpContext.User.FindFirst(ConfigKeys.UserId)?.Value;
                return idUser == null ? Guid.Empty : Guid.Parse(idUser);
            }
        }
    }
}