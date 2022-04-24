using Health.DataService.Data;
using Health.DataService.Dtos.Incoming;
using Health.Entity.DbSet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Tracking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext? _context;

        public UsersController(AppDbContext context)
        {
                _context = context;
        }


        /// <summary>
        /// Get all user from database
        /// </summary>
        /// <returns>return a list</returns>



        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context?.Users.Where(x => x.status == 1).ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            var _user = new User();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Email = user.Email;
            _user.DateOfBirth =Convert.ToDateTime( user.DateOfBirth);
            _user.Phone = user.Phone;
            _user.Country = user.Country;
            _user.status = 1;

            _context?.Users.Add(_user);   
            _context?.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var user = _context?.Users.FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }
       

    }
}
