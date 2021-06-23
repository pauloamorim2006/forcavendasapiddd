using ERP.Api.Controllers;
using ERP.Core.Notificacoes;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuarios")]
    public class UsuariosController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsuariosController(UserManager<IdentityUser> userManager,
            INotificador notificador,
            IUser user) : base(notificador, user)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IEnumerable<IdentityUser> ObterTodos()
        {
            return _userManager.Users.ToList();
        }
    }
}