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
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterests> PersonInterests { get; set; }
        public DbSet<InterestLinks> InterestLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mapping PersonInterest
            modelBuilder.Entity<PersonInterests>()
                .HasKey(pi => new {pi.PersonID, pi.InterestID});

            modelBuilder.Entity<PersonInterests>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonID);

            modelBuilder.Entity<PersonInterests>()
                .HasOne(pi => pi.Interests)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestID);



            //mapping PersonInterest
            modelBuilder.Entity<InterestLinks>()
                .HasKey(pil => new { pil.LinkID, pil.InterestID});

            modelBuilder.Entity<InterestLinks>()
                .HasOne(pil => pil.Link)
                .WithMany(l => l.InterestLinks)
                .HasForeignKey(pil => pil.LinkID);

            modelBuilder.Entity<InterestLinks>()
                .HasOne(pil => pil.Interest)
                .WithMany(i => i.InterestLinks)
                .HasForeignKey(pil => pil.InterestID);

            //Seed data
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 1,
                InterestTitle = "Surfing",
                InterestsDescription = "Väldigt kul, vatten"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestID = 2,
                InterestTitle = "Matlagning",
                InterestsDescription = "Väldigt kul, ingredienser och grejer"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
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
               
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonID = 2,
                FirstName = "Eva",
                LastName = "Johansson",
                PhoneNumber = 0731234567

            });
            modelBuilder.Entity<PersonInterests>().HasData(new PersonInterests
            {
                PersonID = 1,
                InterestID = 1
            });
            modelBuilder.Entity<PersonInterests>().HasData(new PersonInterests
            {
                PersonID = 1,
                InterestID = 2
            });
            modelBuilder.Entity<PersonInterests>().HasData(new PersonInterests
            {
                PersonID = 2,
                InterestID = 1
            });

            modelBuilder.Entity<Link>().HasData(new Link
            {

                LinkID = 1,
                LinkSite = "https://magnusandfriends.se/sv/den-kompletta-surf-guiden/?gad_source=1&gclid=Cj0KCQjwjLGyBhCYARIsAPqTz18D50Ic8DNB1AC5G4p9x7sPzTO-06fC7Xs3faEYufv1PEYx2y0ez-gaAn4VEALw_wcB"

            });
            modelBuilder.Entity<Link>().HasData(new Link
            {

                LinkID = 2,
                LinkSite = "https://www.lapoint.se/?gad_source=1&gclid=Cj0KCQjw3tCyBhDBARIsAEY0XNkNh8aYEYYJ5v36jgFFx0-Zr2-ZBaodHOYuDRXhyjkWp-uxJCTRI94aAoocEALw_wcB"

            });
            modelBuilder.Entity<InterestLinks>().HasData(
               new InterestLinks {  LinkID = 1, InterestID = 1 },
               new InterestLinks {  LinkID = 2, InterestID = 1 }
           );

        }
    }
}
