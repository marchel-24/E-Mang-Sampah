using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Model
{
    public partial class UserAccount
    {
        /// <summary>
        /// Gets the full name of the user by combining the first name and last name.
        /// </summary>
        /// <returns>The full name of the user.</returns>
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        /// <summary>
        /// Adds the specified amount of experience points (XP) to the user's account.
        /// </summary>
        /// <param name="xpToAdd">The amount of experience points to add.</param>
        public void AddXp(int xpToAdd)
        {
            Xp += xpToAdd;
        }
    }
}
