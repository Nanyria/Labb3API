using Microsoft.EntityFrameworkCore;
using SUT23TeknikButikModels;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<PersonInterests> PersonInterests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed data
            modelBuilder.Entity<Interests>().HasData(new Interests
            {
                InterestID = 1,
                InterestTitle = "Surfing",
                InterestsDescription = "Väldigt kul, vatten"
            });
            modelBuilder.Entity<Interests>().HasData(new Interests
            {
                InterestID = 2,
                InterestTitle = "Matlagning",
                InterestsDescription = "Väldigt kul, ingredienser och grejer"
            });
            modelBuilder.Entity<Interests>().HasData(new Interests
            {
                InterestID = 3,
                InterestTitle = "Datorspel",
                InterestsDescription = "Väldigt kul, dator"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonID = 1,
                FirstName = "Adam",
                LastName = "Andersson",
                PhoneNumber = 042552525,
                Interests = 
            });
        }
    }
}
