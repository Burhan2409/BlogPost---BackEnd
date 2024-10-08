using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Models
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public string? Title { get; set; }

        public string? PostDescription { get; set; }

        //public DateOnly CreatedDate { get; set; }

      
    }
}
