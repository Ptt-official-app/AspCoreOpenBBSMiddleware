using ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MWDBContext : DbContext
    {
        public MWDBContext()
        { }
        public MWDBContext(DbContextOptions<MWDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Moderator> Moderators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(e => e.BoardId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.BoardSN).HasMaxLength(50);
            });

            modelBuilder.Entity<Moderator>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserSN).HasMaxLength(50);
            });
        }
    }
}
