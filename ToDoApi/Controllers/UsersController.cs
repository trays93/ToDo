using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToDoCore.Entities;
using ToDoCore.Repositories;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository
                ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userRepository.GetUsers());
        }
    }
}
