using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Api.DataAccess.Models;
using Task.Api.DataAccess.Models.Parameters;
using Task = Task.Api.DataAccess.Models.Task;

namespace Task.Api.Controllers
{
    [Route("api/Users/{userId:int}/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksContext _context;

        public TasksController(TasksContext context)
        {
            _context = context;
        }

        // GET: api/Tasks/5
        [HttpGet("Get")]
        public async Task<ActionResult<DataAccess.Models.Task[]>> Get(int userId)
        {
            try
            {
                DataAccess.Models.Task[] task = await _context.Tasks.Where(m => m.UserId.Equals(userId)).ToArrayAsync();

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DataAccess.Models.Task>> Get(int userId, int id)
        {
            try
            {
                DataAccess.Models.Task task = await _context.Tasks.FindAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<DataAccess.Models.Task>> Update(int userId, int id, PutTaskParam task)
        {
            try
            {
                if (id != task.Id)
                {
                    return BadRequest();
                }

                DataAccess.Models.Task t = await _context.Tasks.FindAsync(task.Id);
                if (t != null)
                {
                    t.UserId = userId;
                    t.Description = task.Description;
                    t.State = task.State;
                    _context.Entry(t).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound($"Could not find Task {id}");
                }

                return Ok(t);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST: api/Tasks
        [HttpPost("Add")]
        public async Task<ActionResult<DataAccess.Models.Task>> Add(int userId, PostTaskParam task)
        {
            try
            {
                DataAccess.Models.Task t = new DataAccess.Models.Task();
                t.UserId = userId;
                t.Description = task.Description;
                t.State = task.State;
                _context.Tasks.Add(t);
                await _context.SaveChangesAsync();

                return Ok(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting Task");
            }
        }

        // DELETE: api/Tasks/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<DataAccess.Models.Task>> Delete(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}