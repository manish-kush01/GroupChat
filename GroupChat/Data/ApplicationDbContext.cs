using GroupChat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupChat.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get;set; }
        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId= 1,
                    UserName="Manish",
                    Password="MyPAss",
                    AssociatedGroups= "",
                    CreatedDate= DateTime.Now
                }
                );
            modelBuilder.Entity<Messages>()
        .HasOne(gm => gm.Group)
        .WithMany(g => g.Messages)
        .HasForeignKey(gm => gm.GroupId);

            modelBuilder.Entity<Messages>()
                .HasOne(gm => gm.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(gm => gm.UserId);
        }
    }
}
