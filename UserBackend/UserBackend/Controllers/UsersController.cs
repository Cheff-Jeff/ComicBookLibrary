using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBackend.Data;
using UserBackend.Modals;

namespace UserBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UsersController(UserDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll() 
            => await _context.Users.ToListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserOne(int id) 
        {
            User? user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Route("AdminLogin")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdmin(AuthModel info)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == info.Email);
            if (user != null)
            { 
                EncryptionHandler handler = new EncryptionHandler();
                if (handler.VerifyPassword(user.Password, user.Salt, info.Password))
                {
                    if (user.IsAdmin) 
                    {
                        return Ok(user);
                    }
                    return BadRequest("Not an admin");
                }
                return BadRequest("Bad login information");
            }
            return BadRequest("User not found");
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(AuthModel info)
        { 
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == info.Email);
            if (user != null)
            {
                EncryptionHandler handler = new EncryptionHandler();
                if (handler.VerifyPassword(user.Password, user.Salt, info.Password))
                {
                    return Ok(user);
                }
                return BadRequest("Bad login information");
            }
            return BadRequest("User not found");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] User newUser)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
            if (user == null)
            {
                newUser.encrypt();
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUserOne), new { id = newUser.Id }, newUser);
            }
            return BadRequest("User already exists");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int id, User user) 
        {
            if (id != user.Id) return BadRequest("User not found");
            _context.Entry(user).State = EntityState.Modified;

            User? emailUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (emailUser == null || emailUser.Id == user.Id)
            {
                user.encrypt();
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("Email already in use.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        { 
            User? user = await _context.Users.FindAsync(id);
            if (user == null) return BadRequest();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
