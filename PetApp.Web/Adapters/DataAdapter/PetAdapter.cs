using PetApp.Data;
using PetApp.DataModels;
using PetApp.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetApp.Web.Adapters.DataAdapter
{
    public class PetAdapter : IPetAdapter
    {
        public List<Pet> GetPets()
        {
            List<Pet> pets;

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                pets = db.Pets.Include("Shelter").ToList();
            }

            return pets;
        }

        public Pet GetPet(int Id)
        {
            Pet myPet;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                myPet = db.Pets.Where(x => x.Id == Id).FirstOrDefault();
            }

            return myPet;
        }

        public void EditPet(Pet pet)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet oldPet = db.Pets.Where(x => x.Id == pet.Id).FirstOrDefault();

                oldPet.Name = pet.Name;
                oldPet.Adopted = pet.Adopted;
                oldPet.Type = pet.Type;

                db.SaveChanges();
            }
        }

        public void AddPet(Pet pet)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Pets.Add(pet);
                db.SaveChanges();
            }
        }

        public void DeletePet(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet deleteMe = db.Pets.Find(Id);
                db.Pets.Remove(deleteMe);

                db.SaveChanges();
            }
        }

        //------------------------------------------

        public List<Shelter> GetShelters()
        {
            List<Shelter> shelters;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                shelters = db.Shelters.ToList();
            }

            return shelters;
        }

        public Shelter GetShelter(int Id)
        {
            Shelter shelter;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                shelter = db.Shelters.Include("Pets").Where(x => x.Id == Id).FirstOrDefault();
            }

            return shelter;
        }

        public void EditShelter(Shelter shelter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Shelter oldShelter = db.Shelters.Find(shelter.Id);

                oldShelter.Name = shelter.Name;
                oldShelter.Location = shelter.Location;
                oldShelter.Pets = shelter.Pets;

                db.SaveChanges();
            }
        }

        public void AddShelter(Shelter shelter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Shelters.Add(shelter);
                db.SaveChanges();
            }
        }

        public void DeleteShelter(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Shelter deleteMe = db.Shelters.Find(Id);
                db.Shelters.Remove(deleteMe);

                db.SaveChanges();
            }
        }
    }
}