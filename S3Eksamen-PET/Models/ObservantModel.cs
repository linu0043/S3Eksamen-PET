using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S3Eksamen_PET.Models
{
    public class ObservantModel : PersonModel
    {
        //Sets the role to Observant immediately
        public override Roles Role
        {
            get { return Roles.Observant; }
            set { Role = Roles.Observant; }
        }

        private string comment;

        /// <summary>
        /// Gets or sets the comment noted for this observant.
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChanged("comment"); }
        }

        /// <summary>
        /// Gets a list of all reports on this observant.
        /// </summary>
        /// <returns>A <c>List</c> of type <c>ReportModel</c>. Returns <c>null</c> if no reports exist.</returns>
        public List<ReportModel> GetReports()
        {
            return null; 
        }

        /// <summary>
        /// Gets an <c>ObservantModel</c> object used for testing.
        /// </summary>
        /// <returns>A test <c>ObservantModel</c>.</returns>
        public static ObservantModel GetTestObservant()
        {
            RegionInfo nationality = new RegionInfo("DK");
            return new ObservantModel
            {
                Id = 0,
                Name = "Vaisna Krishnarajah",
                Comment = "VK blev arresteret af leder LB d. 20. April kl. 16:20 efter samtlige gange at være too fucking hot",
                Address = "Vestervej 4",
                City = "Stenlille",
                PostalCode = "4269",
                PhoneNo = "69420069",
                Email = "kitty@billemand.com",
                Nationality = nationality,
                CPR = "1006029999",
                Height = 159,
                EyeColor = "Brun",
                HairColor = "Sort",
                Photo = null
            };
        }

        /// <inheritdoc/>
        public override bool VerifyPerson()
        {
            // Check if inherited properties are valid, then verify own properties
            if (!base.VerifyPerson() &&
                string.IsNullOrWhiteSpace(comment))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
        