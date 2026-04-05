using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blooging.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Title is required.")]
        [StringLength(400, ErrorMessage = "Title cannot be longer than 400 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters.")]
        public string Author { get; set; }  

        public string FeaturesImagePath { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }= DateTime.Now;


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }


        public ICollection<Comment> Comments { get; set; }  


    }
}
