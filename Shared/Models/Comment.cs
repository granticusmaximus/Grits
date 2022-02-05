using System.ComponentModel.DataAnnotations;

namespace Grits.Shared.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
    }
}
