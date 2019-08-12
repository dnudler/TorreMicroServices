using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Torre.Web.Models;

namespace Torre.Web.ViewModels
{
    public class TasksViewModel
    {

        public TasksViewModel(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; }
        public User User { get; set; }
        public ICollection<Models.Task> Tasks { get; set; }
    }
}
