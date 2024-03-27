using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoommateBackend.Models;

namespace RoommateBackend.Data
{
    public class ApplicationDBContext: IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Rooms)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.SavedRooms)
                .WithMany(r => r.SavedBy)
                .UsingEntity(j => j.ToTable("SavedRooms"));

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Rooms)
                .HasForeignKey(r => r.OwnerId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Images)
                .WithOne()
                .HasForeignKey("RoomId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}