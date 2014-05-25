using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using PetApp.DataModels;

namespace PetApp.Data
{
    public static class Seeder
    {
        public static void Seed(
            ApplicationDbContext context, 
            bool seedShelter =  true, bool seedPets = true, bool seedVolunteers = true)
        {
            if (seedShelter)
            {
                Seeder.Shelters(context);
            }

            if(seedPets)
            {
                Seeder.Pets(context);
            }

            if(seedVolunteers)
            {
                Seeder.Volunteers(context);
            }
        }

        private static void Shelters(ApplicationDbContext context)
        {
            context.Shelters.AddOrUpdate(
                    s => s.Name,
                    new Shelter() { Name = "BARC Animal Shelter & Adoptions", Location = "3200 Carr St. Houston, TX"},
                    new Shelter() { Name = "Friends For Life No Kill Shelter", Location = "107 E. 22nd St. Houston, TX" },
                    new Shelter() { Name = "Citizens For Animal Protection", Location = "17555 Katy Fwy Houston, TX" },
                    new Shelter() { Name = "Harris County Veterinary", Location = "612 Canino Rd. Houston, TX" },
                    new Shelter() { Name = "Special Pals", Location = "3830 Greenhouse Rd Houston, TX" },
                    new Shelter() { Name = "Texas Wildlife Rehab Coalition", Location = "10801 Hammerly Blvd Houston, TX" }
                );

            context.SaveChanges();

        }

        private static void Pets(ApplicationDbContext context)
        {
            context.Pets.AddOrUpdate(
                    p => p.Name,
                    new Pet() { Name ="butch", ShelterId = 1,Type = PetType.Dog},
                    new Pet() { Name = "Katy", ShelterId = 2, Type = PetType.Dog },
                    new Pet() { Name = "ronny", ShelterId = 3, Type = PetType.Dog },

                    new Pet() { Name = "sally", ShelterId = 1, Type = PetType.Cat },
                    new Pet() { Name = "jane", ShelterId = 2, Type = PetType.Cat },
                    new Pet() { Name = "farris", ShelterId = 3, Type = PetType.Cat },

                    new Pet() { Name = "bruce", ShelterId = 1, Type = PetType.Lizard},
                    new Pet() { Name = "eve", ShelterId = 2, Type = PetType.Lizard},
                    new Pet() { Name = "steve", ShelterId = 3, Type = PetType.Lizard},

                    new Pet() { Name = "seth", ShelterId = 1, Type = PetType.Hamster },
                    new Pet() { Name = "grace", ShelterId = 2, Type = PetType.Hamster },
                    new Pet() { Name = "jim", ShelterId = 3, Type = PetType.Hamster },

                    new Pet() { Name ="ronald", ShelterId = 1,Type = PetType.Dog },
                    new Pet() { Name ="harry", ShelterId = 2,Type =PetType.Cat },
                    new Pet() { Name ="steward", ShelterId = 3,Type =PetType.Hamster }
                );

            context.SaveChanges();
        }

        private static void Volunteers(ApplicationDbContext context)
        {
            context.Volunteers.AddOrUpdate(
                 o => new { o.FirstName, o.LastName },
                 new Volunteer() { FirstName = "Andre'", LastName = "Jones"}
                );
        }
    }
}
