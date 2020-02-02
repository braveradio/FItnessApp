using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Title of gender</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender field cannot be empty or null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}