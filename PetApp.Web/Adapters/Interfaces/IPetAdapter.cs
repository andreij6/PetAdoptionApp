using PetApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.Web.Adapters.Interfaces
{
    public interface IPetAdapter
    {
        List<Pet> GetPets();

        Pet GetPet(int Id);

        void EditPet(Pet pet);

        void AddPet(Pet pet);

        void DeletePet(int Id);


        List<Shelter> GetShelters();

        Shelter GetShelter(int Id);

        void EditShelter(Shelter shelter);

        void AddShelter(Shelter shelter);

        void DeleteShelter(int Id);
    }
}
