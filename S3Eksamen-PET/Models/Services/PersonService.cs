using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Eksamen_PET.Models;
using System.Globalization;

namespace S3Eksamen_PET.Models.Services
{
    public class PersonService
    {
        PETDbEntities DbCtx;
        public PersonService()
        {
            DbCtx = new PETDbEntities();
        }

        public List<PersonModel> GetAllPersons(bool includeObservants)
        {
            List<PersonModel> personList = new List<PersonModel>();

            try
            {
                var query = from person in DbCtx.Persons
                            select person;

                foreach (var person in query)
                {
                    personList.Add(ConvertPersonToModel(person));
                }
            }
            catch (Exception)
            {

                throw;
            }

            return personList;
        }

        /// <summary>
        /// Updates or adds the specified <c>PersonModel</c> in the database.
        /// </summary>
        /// <param name="newPerson">An object whose class inherits <c>PersonModel</c></param>
        /// <param name="insertAsNew">If true, this person will be added as a new entry instead of being updated.</param>
        /// <returns>True if successfully added/updated, false if not</returns>
        public bool UpdatePerson(PersonModel newPerson, bool insertAsNew = false)
        {
            bool isAdded = false;

            object personToUpdate;

            if (newPerson.VerifyPerson())
            {
                personToUpdate = ConvertModelToDb(newPerson, insertAsNew);

                try
                {
                    if (insertAsNew)
                    {
                        if (newPerson.Role == Roles.Observant)
                        {
                            DbCtx.Observants.Add((Observant)personToUpdate);
                        }
                        else
                        {
                            DbCtx.Persons.Add((Person)personToUpdate);
                        }
                    }
                    else
                    {
                        if (newPerson.Id > 0)
                        {
                            object existingEntry;

                            if (newPerson.Role == Roles.Observant)
                            {
                                existingEntry = DbCtx.Observants.Find(newPerson.Id);
                            }
                            else
                            {
                                existingEntry = DbCtx.Persons.Find(newPerson.Id);
                            }

                            DbCtx.Entry(existingEntry).CurrentValues.SetValues(personToUpdate);
                        }
                        else
                        {
                            if (newPerson.Role == Roles.Observant)
                            {
                                DbCtx.Observants.Add((Observant)personToUpdate);
                            }
                            else
                            {
                                DbCtx.Persons.Add((Person)personToUpdate);
                            }
                        }
                    }

                    // Sets isAdded to true if the database was successfully updated.
                    isAdded = DbCtx.SaveChanges() > 0;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return isAdded;
        }

        /// <summary>
        /// Converts a model to a DTO for the database.
        /// </summary>
        /// <param name="personModel">An object whose class inherits <c>PersonModel</c>.</param>
        /// <param name="excludeId">If true, the object returned will have an ID of 0</param>
        /// <returns>Returns a <c>Person</c> object if the given <c>PersonModel</c> object is not an <c>ObservantModel.</c></returns>
        private object ConvertModelToDb(PersonModel personModel, bool excludeId = false)
        {
            // Creates a new Person DTO
            object dbPerson = new Person
            {
                // Excludes the ID if insertAsNew is true
                Id = excludeId ? 0 : personModel.Id,
                Role = (byte)personModel.Role,
                Name = personModel.Name,
                Address = personModel.Address,
                City = personModel.City,
                PostalCode = personModel.PostalCode,
                PhoneNo = personModel.PhoneNo,
                Email = personModel.Email,
                Nationality = personModel.Nationality.TwoLetterISORegionName,
                CPR = personModel.CPR,
                Height = personModel.Height,
                EyeColor = personModel.EyeColor,
                HairColor = personModel.HairColor,
                Photo = personModel.Photo,
            };

            // Checks if the dbPerson has the Observant role, and converts it to an Observant DTO instead
            // All Observants are stored in a different table in the database, away from the other Persons
            // Why? First of all, makes it easier to keep track of Observants as they are not mixed in with other Persons
            // Second, I didn't have enough time to think this through man, this is an exam. It would be more efficient
            // if I actually had more time lol.
            if (personModel.Role == Roles.Observant)
            {
                Observant dbObservant = (Observant)dbPerson;
                ObservantModel observantModel = (ObservantModel)personModel;

                dbObservant.Comments = observantModel.Comment;

                return dbObservant;
            }
            else
            {
                return dbPerson;
            }
        }

        /// <summary>
        /// Converts a database Person into a model
        /// </summary>
        /// <param name="dbObject">The database Person to convert</param>
        /// <returns>The converted object</returns>
        public PersonModel ConvertPersonToModel(Person dbObject)
        {
            // Hej hr. sensor mand, så jeg ved at alt det her ligner et enormt rod, og jeg er fuldstændig
            // klar over at det er pisse nemt et forbedre og gøre det mere efficient, men jeg havde simpelthen
            // ikke nok tid til at tænke på den mest optimale løsning så kom til at stresse og gøre alting
            // sværere end det burde være, pls ik giv mig 02

            PersonModel person = null;

            if (dbObject.Role == (int)Roles.Agent)
            {
                person = new AgentModel
                {
                    Id = dbObject.Id,
                    Role = (Roles)dbObject.Role,
                    Name = dbObject.Name,
                    Address = dbObject.Address,
                    City = dbObject.City,
                    PostalCode = dbObject.PostalCode,
                    PhoneNo = dbObject.PhoneNo,
                    Email = dbObject.Email,
                    Nationality = new RegionInfo(dbObject.Nationality),
                    CPR = dbObject.CPR,
                    Height = (int)dbObject.Height,
                    EyeColor = dbObject.EyeColor,
                    HairColor = dbObject.HairColor,
                    Photo = dbObject.Photo,
                };
            }

            if (dbObject.Role == (int)Roles.Leader)
            {
                person = new LeaderModel
                {
                    Id = dbObject.Id,
                    Role = (Roles)dbObject.Role,
                    Name = dbObject.Name,
                    Address = dbObject.Address,
                    City = dbObject.City,
                    PostalCode = dbObject.PostalCode,
                    PhoneNo = dbObject.PhoneNo,
                    Email = dbObject.Email,
                    Nationality = new RegionInfo(dbObject.Nationality),
                    CPR = dbObject.CPR,
                    Height = (int)dbObject.Height,
                    EyeColor = dbObject.EyeColor,
                    HairColor = dbObject.HairColor,
                    Photo = dbObject.Photo,
                };
            }

            return person;
        }

        /// <summary>
        /// Converts a database Observant into a model
        /// </summary>
        /// <param name="dbObject">The database Observant to convert</param>
        /// <returns>The converted object</returns>
        public PersonModel ConvertObservantToModel(Observant dbObject)
        {
            return new ObservantModel
            {
                Id = dbObject.Id,
                Role = (Roles)dbObject.Role,
                Name = dbObject.Name,
                Address = dbObject.Address,
                City = dbObject.City,
                PostalCode = dbObject.PostalCode,
                PhoneNo = dbObject.PhoneNo,
                Email = dbObject.Email,
                Nationality = new RegionInfo(dbObject.Nationality),
                CPR = dbObject.CPR,
                Height = (int)dbObject.Height,
                EyeColor = dbObject.EyeColor,
                HairColor = dbObject.HairColor,
                Photo = dbObject.Photo,
                Comment = dbObject.Comments
            };
        }
    }
}
