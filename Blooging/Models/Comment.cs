using System.ComponentModel.DataAnnotations;

namespace Blooging.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "User name is required.")]
        [StringLength(100, ErrorMessage = "User name cannot be longer than 100 characters.")]
        public string UserName { get; set; }

        [DataType (DataType.Date)]
        public DateTime CommentDate { get; set; }

        [Required]
        public string Content { get; set; }


    }
}
