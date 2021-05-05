using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S3Eksamen_PET.Models
{
    public class LeaderModel : PersonModel
    {
        //Sets the role to Leader immediately
        public override Roles Role
        {
            get { return Roles.Leader; }
            set { Role = Roles.Leader; }
        }

        /// <summary>
        /// Gets an <c>LeaderModel</c> object used for testing.
        /// </summary>
        /// <returns>A test <c>LeaderModel</c>.</returns>
        public static LeaderModel GetTestLeader()
        {
            RegionInfo nationality = new RegionInfo("DK");
            return new LeaderModel
            {
                Id = 0,
                Name = "Test Leder Mand",
                Address = "Boholtevej 25",
                City = "Køge",
                PostalCode = "4600",
                PhoneNo = "42421763",
                Email = "linu0043@edu.campusvejle.dk",
                Nationality = nationality,
                CPR = "1509007019",
                Height = 180,
                EyeColor = "Grøn",
                HairColor = "Brun",
                Photo = null
            };
        }
    }
}
