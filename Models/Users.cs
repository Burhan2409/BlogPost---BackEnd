using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Models
{
    public class Users
    {
        [Key]
        public int UserId {  get; set; }
        
        
        public string? UserName { get; set; }

        
        public string? UserPassword { get; set; }
    }
}
