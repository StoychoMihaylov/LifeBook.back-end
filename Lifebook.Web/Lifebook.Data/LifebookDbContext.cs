namespace Lifebook.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LifebookDbContext : IdentityDbContext<ApplicationUser>
    {
        public LifebookDbContext()
            : base("name=LifebookDbContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public static LifebookDbContext Create()
        {
            return new LifebookDbContext();
        }
    }
}