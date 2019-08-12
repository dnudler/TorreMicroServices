using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using User.Api.DataAccess.Models;
using User.Api.DataAccess.Models.Parameters;
using User = User.Api.DataAccess.Models.User;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<DataAccess.Models.User>>> All()
        {
            try
            {
                return Ok(await _context.Users.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DataAccess.Models.User>> Get(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // PUT: api/Users/5
        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, PutUserParam u)
        {
            try
            {
                if (id != u.Id)
                {
                    return BadRequest();
                }

                DataAccess.Models.User user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    user.Name = u.Name;
                    _context.Entry(user).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                return NotFound($"Could not find user {id}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<DataAccess.Models.User>> Add([FromBody]PostUserParam u)
        {
            try
            {
                DataAccess.Models.User user = new DataAccess.Models.User();
                user.Name = u.Name;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult<DataAccess.Models.User>> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"Could not find user {id}");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Item cannot be deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
