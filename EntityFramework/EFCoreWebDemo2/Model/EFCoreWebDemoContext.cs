    using Microsoft.EntityFrameworkCore;
    namespace EFCoreWebDemo
    {
        public class EFCoreWebDemoContext : DbContext
        {
            public DbSet<Review> Reviews {get; set;}
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=EFCoreWebDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }