using System.ComponentModel.DataAnnotations;

namespace User.Api.DataAccess.Models.Parameters
{
    public class PostUserParam
    {
        [Required]

        public string Name { get; set; }

    }
}
