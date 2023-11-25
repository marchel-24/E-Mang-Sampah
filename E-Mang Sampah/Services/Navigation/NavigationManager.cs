using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_Mang_Sampah.Services.Navigation
{
    /// <summary>
    /// Provides navigation functionality for handling window navigation
    /// </summary>
    internal class NavigationManager
    {
        private Window currentWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationManager"/> class.
        /// </summary>
        /// <param name="window">The current window instance.</param>  
        public NavigationManager(Window window)
        {
            currentWindow = window;
        }

        /// <summary>
        /// Navigates to the specified window, showing it and hiding the current window.
        /// </summary>
        /// <param name="destinationWindow">The window to navigate to.</param>
        public void NavigateWindow(Window destinationWindow)
        {
            destinationWindow.Show();
            currentWindow.Hide();
        }
    }
}
