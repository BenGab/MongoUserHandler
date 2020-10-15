using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserHandler.Db.Models;
using UserHandler.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserHandler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userRepository.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return userRepository.Create(user);
        }

        // PUT api/users/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            userRepository.Update(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.Remove(id);
        }
    }
}
