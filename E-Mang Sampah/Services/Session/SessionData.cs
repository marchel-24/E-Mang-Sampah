using E_Mang_Sampah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_Mang_Sampah.Services.Session
{
    /// <summary>
    /// Provides sessions to maintain an account accross the application windows or pages
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

        private static Window _currentWindow;

        /// <summary>
        /// Gets or sets the current active <see cref="Window"/> instance.
        /// </summary>
        public static Window CurrentWindow
        {
            get { return _currentWindow; }
            set { _currentWindow = value; }
        }
    }
}
