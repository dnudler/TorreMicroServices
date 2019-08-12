using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Api.DataAccess.Models
{
    [Table("Tasks")]
    public class Task
    {
        public Task()
        {
            
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Description { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
