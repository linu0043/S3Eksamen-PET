using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Eksamen_PET.Models;
using S3Eksamen_PET.Models.Services;

namespace S3Eksamen_PET.ViewModel
{
    public class PersonViewModel
    {
        private PersonService PersonService;

        public PersonViewModel()
        {
            PersonService = new PersonService();
        }

        public List<PersonModel> GetAllPersons()
        {
            return PersonService.GetAllPersons(false);
        }

        public bool SavePerson(PersonModel person)
        {
            return PersonService.UpdatePerson(person);
        }
    }
}
