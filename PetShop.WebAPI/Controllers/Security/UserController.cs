using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Infrastructure.Security;
using PetShop.Infrastructure.Security.SecurityInterfaces;

namespace PetShop.WebAPI.Controllers.Security
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> _userRepo;

        public UserController(IRepository<User> userRepo, ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepo = userRepo;
        }
    }
}