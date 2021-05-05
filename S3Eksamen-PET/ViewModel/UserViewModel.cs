using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Eksamen_PET.Models;
using S3Eksamen_PET.Models.Services;

namespace S3Eksamen_PET.ViewModel
{
    public class UserViewModel
    {
        private UserService UserService;
        public UserModel CurrentUser = null;

        public UserViewModel()
        {
            UserService = new UserService();
        }

        /// <summary>
        /// Attempts to log in a user with a username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if successfully logged in, false if not</returns>
        public bool Login(string username, string password)
        {
            bool isValid;

            UserModel user = UserService.GetUserByCredentials(username, password);

            if (user != null)
            {
                isValid = true;

                CurrentUser = user;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

        public void GuestLogin()
        {
            CurrentUser = new UserModel {
                Id = 0,
                Person = AgentModel.GetTestAgent(),
                Username = "GuestAgent",
                Password = "guest"
            };
        }

        /// <summary>
        /// Returns a user with a specific rank to test the program.
        /// </summary>
        /// <param name="role">The role of the test user</param>
        /// <returns>A <c>UserModel</c> object. Returns null if the role is Observant.</returns>
        public static UserModel GetTestPerson(Roles role)
        {
            UserModel user = null;

            switch (role)
            {
                case Roles.Observant:
                    break;
                case Roles.User:
                    user = new UserModel
                    {
                        Id = 0,
                        Person = null,
                        Username = "Testbruger User"
                    };
                    break;
                case Roles.Agent:
                    user = new UserModel
                    {
                        Id = 0,
                        Person = AgentModel.GetTestAgent(),
                        Username = "Testbruger Agent"
                    };
                    break;
                case Roles.Leader:
                    user = new UserModel
                    {
                        Id = 0,
                        Person = LeaderModel.GetTestLeader(),
                        Username = "Testbruger Leder"
                    };
                    break;
                default:
                    break;
            }

            return user;
        }
    }
}
