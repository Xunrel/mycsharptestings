using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaCommon.Entities;

namespace CinemaCommon.Context
{
    public class CinemaContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public CinemaContext()
            : base("CinemaMvcDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CinemaContext>());
        }
    }
}
