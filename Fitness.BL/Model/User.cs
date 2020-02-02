using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; set; }
        //public DateTime Birthdate { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Creating new User
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthdate"> Birthdate. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region check input parameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name cannot be empty or null.", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null.", nameof(gender));
            }
            if(birthdate < DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now)
            {
                throw new ArgumentNullException("Impossible date of birthday.", nameof(birthdate));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Weight cannot be equal or less than 0.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("Height cannot be equal or less than 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name cannot be empty or null.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
