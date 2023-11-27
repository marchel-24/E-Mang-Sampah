using E_Mang_Sampah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Services.Session
{
    /// <summary>
    /// Provides sessions to maintain an account accross the application windows or page
    /// </summary>
    internal partial class SessionData
    {
        private static Account _currentAccount;

        /// <summary>
        /// Current active <see cref="Account"/> class
        /// </summary>
        public static Account CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; }
        }
    }
}
