namespace LifeBook.Models.BindingModels.ArticlesBms
{
    using LifeBook.Models.EntityModels;
    using System;
    using System.Collections.Generic;

    public class ArticleBm
    {
        public DateTime Date { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<byte[]> Images { get; set; }

        public string AuthorId { get; set; }
    }
}
