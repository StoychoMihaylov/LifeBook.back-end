namespace LifeBook.Models.ViewModels.ArticlesVms
{
    using LifeBook.Models.EntityModels;
    using System;
    using System.Collections.Generic;

    public class DetailedArticleVm
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<byte[]> Image { get; set; }

        public string Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
