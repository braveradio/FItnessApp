using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Controller of user.
    /// </summary>
    /// 
    
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// App user.
        /// </summary>
        public User User { get; }
        public List<User> Users { get; set; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Creating new Controller of user.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            // Checking input
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name cannot be empty", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
           

            //User = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
        }

        /// <summary>
        /// Get saved data of Users
        /// </summary>
        /// <returns>App user</returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // check input

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
            Save();
        }

        /// <summary>
        /// Save User data
        /// </summary>

        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}
