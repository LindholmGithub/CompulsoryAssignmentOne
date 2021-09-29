using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Infrastructure.Security;
using PetShop.Infrastructure.Security.Helpers;
using PetShop.Infrastructure.Security.SecurityInterfaces;

namespace PetShop.WebAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IAuthenticationHelper _authentication;

        public RegisterUserController(ILogger<UserController> logger, IRepository<User> userRepo, IRepository<Role> roleRepo, IAuthenticationHelper authentication)
        {
            _logger = logger;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _authentication = authentication;
        }
    }
}