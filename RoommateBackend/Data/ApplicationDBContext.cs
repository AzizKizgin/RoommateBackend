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
        public DbSet<RoomImage> RoomImages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole {Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole {Name = "User", NormalizedName = "USER"}
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Room and RoomImage (one-to-many)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Images)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser and Room (many-to-one as owner)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Rooms)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            // AppUser and Room (many-to-many as saved rooms)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.SavedRooms)
                .WithMany(r => r.SavedBy)
                .UsingEntity(j => j.ToTable("SavedRooms"));

            // Room and RoomAddress (one-to-one)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Address)
                .WithOne(a => a.Room)
                .HasForeignKey<RoomAddress>(a => a.RoomId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}