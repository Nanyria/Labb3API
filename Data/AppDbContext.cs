﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<PersonalInterestLinks> PersonalInterestLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mapping PersonInterest
            modelBuilder.Entity<PersonInterests>()
                .HasKey(pi => new {pi.InterestID,  pi.PersonID});

            modelBuilder.Entity<PersonInterests>()
                .HasOne(pi => pi.Interests)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestID);

            modelBuilder.Entity<PersonInterests>()
                .HasOne(pi => pi.person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonID);


            //mapping PersonInterest
            modelBuilder.Entity<PersonalInterestLinks>()
                .HasKey(pil => new { pil.PersonID, pil.LinkID, pil.InterestID});

            modelBuilder.Entity<PersonalInterestLinks>()
                .HasOne(pil => pil.People)
                .WithMany(p => p.personalInterestLinks)
                .HasForeignKey(pil => pil.PersonID);

            modelBuilder.Entity<PersonalInterestLinks>()
                .HasOne(pil => pil.Link)
                .WithMany(l => l.personalInterestLinks)
                .HasForeignKey(pil => pil.LinkID);

            modelBuilder.Entity<PersonalInterestLinks>()
                .HasOne(pil => pil.Interest)
                .WithMany(i => i.personalInterestLinks)
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
            modelBuilder.Entity<PersonalInterestLinks>().HasData(
               new PersonalInterestLinks { PersonID = 1, LinkID = 1, InterestID = 1 },
               new PersonalInterestLinks { PersonID = 2, LinkID = 1, InterestID = 1 }
           );

        }
    }
}
