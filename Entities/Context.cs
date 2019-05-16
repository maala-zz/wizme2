using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizme.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
        public DbSet<Venue> Venues { set; get; }
        public DbSet<Space> Spaces { get; set; }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            base.OnModelCreating(bldr);
            bldr.Entity<Venue>().HasData(
                new Venue { Id = id1,Descreption = "my first venue"}
            );
            bldr.Entity<Venue>().HasData(
                new Venue { Id = id2, Descreption = "my second venue" }
            );
            bldr.Entity<Venue>().HasData(
                new Venue { Id = id3, Descreption = "my third venue" }
            );
            bldr.Entity<Space>().HasData(
                new Space { Id = Guid.NewGuid(),VenueId=id1,Price=1.01,Shape="U-Theatre" }
            );
            bldr.Entity<Space>().HasData(
                new Space { Id = Guid.NewGuid(), VenueId = id1, Price = 1.01, Shape = "Shape2" }
            );
            bldr.Entity<Space>().HasData(
                new Space { Id = Guid.NewGuid(), VenueId = id1, Price = 1.01, Shape = "Shape3" }
            );
            bldr.Entity<Space>().HasData(
                new Space { Id = Guid.NewGuid(), VenueId = id2, Price = 2.0, Shape = "Square" }
            );
            bldr.Entity<Space>().HasData(
                new Space { Id = Guid.NewGuid(), VenueId = id2, Price = 2.0, Shape = "3atees" }
            );
        }
    }

}