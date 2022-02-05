using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Grits.Shared.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string HeaderImage { get; set; }
        public Comment Comment { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
