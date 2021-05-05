using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S3Eksamen_PET.Models
{
    public class AgentModel : PersonModel
    {
        //Sets the role to Agent immediately
        public override Roles Role
        {
            get { return Roles.Agent; }
            set { Role = Roles.Agent; }
        }

        /// <summary>
        /// Gets an <c>AgentModel</c> object used for testing.
        /// </summary>
        /// <returns>A test <c>AgentModel</c>.</returns>
        public static AgentModel GetTestAgent()
        {
            RegionInfo nationality = new RegionInfo("US");
            return new AgentModel
            {
                Id = 0,
                Name = "Test Agent Bille",
                Address = "Random adresse",
                City = "Random",
                PostalCode = "0000",
                PhoneNo = "69696969",
                Email = "random@email.com",
                Nationality = nationality,
                CPR = "0101004200",
                Height = 230,
                EyeColor = "Rød",
                HairColor = "Rød",
                Photo = null
            };
        }
    }
}
