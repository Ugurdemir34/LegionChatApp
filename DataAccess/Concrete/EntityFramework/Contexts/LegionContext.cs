using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class LegionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=****;Database=Legion;Trusted_Connection=true");
        }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserHobby> UserHobbies { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHobby>().HasKey(i => new { i.UserId, i.HobbyId });

            modelBuilder.Entity<UserLanguage>().HasKey(i => new { i.UserId, i.LanguageId });

            modelBuilder.Entity<UserLanguage>()
                .HasOne(u => u.User)
                .WithMany(a => a.UserLanguages)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<UserLanguage>()
             .HasOne(u => u.Language)
             .WithMany(a => a.UserLanguages)
             .HasForeignKey(b => b.LanguageId);


        }


    }
}
