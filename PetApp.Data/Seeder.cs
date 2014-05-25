using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        private static void Pets(ApplicationDbContext context)
        {

        }

        private static void Volunteers(ApplicationDbContext context)
        {

        }
    }
}
