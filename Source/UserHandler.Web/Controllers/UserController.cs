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

        /// <summary>
        /// Get All users from Api
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// GET api/users/
        /// </remarks>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">id of user</param>
        /// <remarks>
        /// Sample Request:
        ///     GET /api/users/1     
        /// </remarks>
        /// <returns>User by id or empty array</returns>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userRepository.GetById(id);
        }

        /// <summary>
        /// Create a New User
            /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /api/users
        ///      {
       ///          "id": 1,
       ///  "name": "Leanne Graham",
      ///  "username": "Bret",
      ///  "email": "Sincere@april.biz",
      ///  "address": {
      ///    "street": "Kulas Light",
      ///    "suite": "Apt. 556",
      ///    "city": "Gwenborough",
      ///    "zipcode": "92998-3874",
      ///    "geo": {
      ///      "lat": "-37.3159",
      ///      "lng": "81.1496"
      ///    }
      ///  },
      ///  "phone": "1-770-736-8031 x56442",
      ///  "website": "hildegard.org",
      ///  "company": {
      ///    "name": "Romaguera-Crona",
      ///    "catchPhrase": "Multi-layered client-server neural-net",
      ///    "bs": "harness real-time e-markets"
      ///  }
  ///}
    /// </remarks>
    /// <param name="user">User Json</param>
    /// <returns>created User</returns>
    [HttpPost]
        public User Post([FromBody] User user)
        {
            return userRepository.Create(user);
        }

        /// <summary>
        /// Upate a current user
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public void Put([FromBody] User user)
        {
            userRepository.Update(user);
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.Remove(id);
        }
    }
}
