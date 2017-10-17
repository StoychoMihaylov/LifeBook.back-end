using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifebook.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]

        public string TextContent { get; set; }

        public string Author { get; set; }

        public DateTime PublishDay { get; set; }
    }
}
