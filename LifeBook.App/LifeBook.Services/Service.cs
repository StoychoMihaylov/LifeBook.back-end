namespace LifeBook.Services
{
    using LifeBook.Data.Interfaces;

    public abstract class Service
    {
        public Service(ILifeBookDBContext context)
        {
            this.Context = context;
        }

        protected ILifeBookDBContext Context { get; set; }
    }
}
