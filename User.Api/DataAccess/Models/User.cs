using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.DataAccess.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
