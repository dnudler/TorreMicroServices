using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Torre.Web.Models;

namespace Torre.Web.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<User>();
        }

        public ICollection<User> Users { get; set; }
    }
}