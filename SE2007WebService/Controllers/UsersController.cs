using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE2007WebService.Models;
using SE2007WebService.Repositories.Interfaces;

namespace SE2007WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            User user = _userRepository.GetUser(id);

            return user;
        }

        [HttpPost]
        public IActionResult AddNewUser(User user)
        {
            _userRepository.AddUser(user);
            return Created("Users", "A new user was created successfully!");
        }
    }
}
