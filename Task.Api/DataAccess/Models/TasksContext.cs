using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task.Api.DataAccess.Models
{
    public class TasksContext : DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

    }
}
