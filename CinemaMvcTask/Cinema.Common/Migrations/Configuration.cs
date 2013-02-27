using CinemaCommon.Entities;

namespace CinemaCommon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
            // Use this if you want to trash data - usually whie using test data
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context.CinemaContext context)
        {
            context.Cinemas.AddOrUpdate(
                c => c.Name,
                new Cinema
                    {
                        Name = "CineTop"
                    });

            context.Movies.AddOrUpdate(
                m => m.Name,
                new Movie
                    {
                        Name = "Movie2",
                        Price = 11.8
                    },
                new Movie
                    {
                        Name = "Movie3",
                        Price = 7
                    });

            context.Rooms.AddOrUpdate(
                r => r.Name,
                new Room
                    {
                        Name = "Room1",
                        Cinema = new Cinema
                                     {
                                         Name = "CineMovie"
                                     },
                        MaxSeats = 20,
                        Movie = new Movie
                                    {
                                        Name = "Movie1",
                                        Price = 9.6
                                    }
                    });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
