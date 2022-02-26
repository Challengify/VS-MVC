using System;
using System.Collections.Generic;
using System.Text;
using Challengify.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Challengify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> DbUsers { get; set; }

        public DbSet<Challenge> DbChallenges { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=app.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Username = "nickname",
                Email = "mail@mail.com",
                IsSubcriber = false,
                XP = 0
            });

            builder.Entity<Challenge>().HasData(new Challenge
            {
                Id = Guid.NewGuid(),
                Name = "challenge name",
                Image = "c:/asdmks/",
                ShortDescription = "short description",
                FullDescription = "full desc",
                MaxParticipants = 3,
                SumOfXP = 10
            });
        }
    }
}
