using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifebook.Models.EntityModels
{
    public class Article
    {
        public int Id { get; set; }

        [Required, StringLength(50)]

        public string Title { get; set; }

        [Required]

        public string TextContent { get; set; }

        [Required]

        public string Author { get; set; }

        [Required]

        public DateTime PublishDay { get; set; }

        [Required]

        public DateTime LastActivityDate { get; set; }

        public byte[] Image1 { get; set; }

        public byte[] Image2 { get; set; }

        public byte[] Image3 { get; set; }

        public byte[] Image4 { get; set; }

        public byte[] Image5 { get; set; }

        public byte[] Image6 { get; set; }

        public byte[] Image7 { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
