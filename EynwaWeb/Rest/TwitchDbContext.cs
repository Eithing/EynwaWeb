using EynwaWeb.Models.Twitch;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EynwaWeb.Rest
{
    public class TwitchDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        public DbSet<DiscordUser> DiscordUsers { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscordUser>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<DiscordUser>().HasData(
                new DiscordUser() { UserId = 219412998803030016, NickName = "Eithing" },
                new DiscordUser() { UserId = 219853099211292672, NickName = "Frieyja" },
                new DiscordUser() { UserId = 297461765061607447, NickName = "Toukan" });

            //modelBuilder.Entity<Game>(entity =>
            //{
            //    entity.HasOne(d => d.DiscordUser)
            //        .WithMany(p => p.Games)
            //        .HasForeignKey("UserId");
            //});

            //modelBuilder.Entity<Game>().HasData(
            //    new Game() { UserId = 1, Id = 1, Name = "Jeu1", StreamTitle = "Titre du stream1" });

            //modelBuilder.Entity<Game>().HasData(
            //    new { UserId = 1, Id = 2, Name = "Jeu2", StreamTitle = "Titre du stream2" });
        }
    }
}
