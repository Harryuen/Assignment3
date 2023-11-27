using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class User : IEquatable<User>
    {
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a User object.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="password">Plain-text password</param>
        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Checks if object is equal to another object.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True of this object is equal to other object</returns>
        public override bool Equals(Object other)
        {
            if (!(other is User otherUser))
			    return false;

            return Name.Equals(otherUser.Name);
        }

        public bool Equals(User other)
        {
            return !(other is null) &&
                   Name == other.Name;
        }

    }
}
