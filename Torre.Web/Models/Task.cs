using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torre.Web.Models
{
    public class Task
    {
        public Task()
        {
            
        }
        public Task(int userId)
        {
            UserId = userId;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Description { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int UserId { get; set; }

        public IEnumerable<SelectListItem> StateList =
            new List<SelectListItem>
            {
                new SelectListItem {Text = "To Do", Value = "0"},
                new SelectListItem {Text = "Done", Value = "1"}
            };

        public string StateDescription
        {
            get
            {
                string stateDesc = "";
                switch (State)
                {
                    case 0:
                        stateDesc = "To do";
                        break;
                    case 1:
                        stateDesc = "Done";
                        break;
                }

                return stateDesc;
            }
        }
    }
}
