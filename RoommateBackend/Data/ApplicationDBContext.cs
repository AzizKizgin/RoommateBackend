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
        public DbSet<RoomAddress> RoomAddresses { get; set; }

        
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

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Rooms)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Or set to Cascade if you want user deletion to cascade to rooms

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Address)
                .WithOne(a => a.Room)
                .HasForeignKey<RoomAddress>(a => a.RoomId);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Rooms)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.SavedRooms)
                .WithMany(r => r.SavedBy)
                .UsingEntity<Dictionary<string, object>>(
                    "UserSavedRooms",
                    ur => ur.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.Cascade),
                    ur => ur.HasOne<AppUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                    ur =>
                    {
                        ur.Property<int>("SavedOn");
                        ur.HasKey("UserId", "RoomId");
                    });

        }
    }
}