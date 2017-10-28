namespace LifeBook.Data.Interfaces
{
    using LifeBook.Models.EntityModels;
    using System.Data.Entity;

    public interface ILifeBookDBContext
    {
        DbSet<Article> Articles { get; set; }

        DbSet<Comment> Comments { get; set; }

        int SaveChanges();
    }
}
