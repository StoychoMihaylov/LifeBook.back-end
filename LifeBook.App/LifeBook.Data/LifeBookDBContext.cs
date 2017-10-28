namespace LifeBook.Data
{
    using LifeBook.Data.Interfaces;
    using LifeBook.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class LifeBookDBContext : IdentityDbContext<ApplicationUser> , ILifeBookDBContext
    {
        public LifeBookDBContext()
            : base("name=LifeBookDBContext")
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public static LifeBookDBContext Create()
        {
            return new LifeBookDBContext();
        }
    }
}