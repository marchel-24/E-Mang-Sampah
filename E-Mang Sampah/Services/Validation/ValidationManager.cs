using E_Mang_Sampah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Services.Authentication
{
    /// <summary>
    /// Provides validation functionality for the apps
    /// </summary>
    internal class ValidationManager
    {
        private EmangSampahModelContainer1 db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationManager"/>
        /// </summary>
        /// <param name="db">The connected database entity</param>
        public ValidationManager(EmangSampahModelContainer1 db)
        {
            this.db = db;
        }

        /// <summary>
        /// Validate username and password based on the data in database
        /// </summary>
        /// <param name="username">The username of the user to validate</param>
        /// <param name="password">The password of the user to validate</param>
        /// <returns></returns>
        public bool Validate(string username, string password)
        {
            return db.Accounts.Where(r => r.Username == username && r.Password == password).Count() > 0;
        }
    }
}
