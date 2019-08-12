using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Api.DataAccess.Models.Parameters
{
    public class PutTaskParam
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Description { get; set; }
        [Required]
        public int State { get; set; }

    }
}
