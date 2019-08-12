using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.DataAccess.Models.Parameters
{
    public class PutUserParam
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
