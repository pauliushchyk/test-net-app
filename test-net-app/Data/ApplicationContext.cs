using Microsoft.EntityFrameworkCore;
using testnetapp.Data.Models;

namespace testnetapp.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookTag>(e =>
            {
                e.HasKey(bt => new { bt.BookId, bt.TagId });

                e.HasOne(bt => bt.Book)
                 .WithMany(b => b.BookTags)
                 .HasForeignKey(bt => bt.BookId);

                e.HasOne(bt => bt.Book)
                 .WithMany(t => t.BookTags)
                 .HasForeignKey(bt => bt.TagId);
            });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
