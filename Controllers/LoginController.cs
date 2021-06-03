using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDoc.Models;
using HomeDoc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HomeDoc.Services;
using Microsoft.AspNetCore.Identity;

namespace HomeDoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
    

        private readonly ILogger<LoginController> _logger;
        IUserService _userManager;

        public LoginController(IUserService userManager,ILogger<LoginController> logger)
        {
            _userManager = userManager;
            _logger = logger;
           
        }


        [HttpPost("login")]
        [AllowAnonymous]
        [EnableCors("CorsPolicy")]
        [Produces("application/json")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok(_userManager.Login(request.email, request.password));

            //retorna o result (se autenticou manda true, senão manda false), id, nome do usuário
        }
    }
}
