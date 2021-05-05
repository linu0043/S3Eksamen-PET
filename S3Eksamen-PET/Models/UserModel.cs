using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen_PET.Models
{
    public class UserModel
    {
        private int id;

        /// <summary>
        /// Gets the ID for this user.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private PersonModel person;

        /// <summary>
        /// Gets the person registered to this user.
        /// </summary>
        public PersonModel Person
        {
            get { return person; }
            set { person = value; }
        }

        private string username;

        /// <summary>
        /// Gets or sets the username for this user.
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        /// <summary>
        /// Gets or sets the password for this user, but in cleartext cus cbfb to make it secure
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
