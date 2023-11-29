using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Model
{
    public partial class Posts
    {
        /// <summary>
        /// Function to add <see cref="LikesCount"/> by one
        /// </summary>
        public void addLikes()
        {
            LikesCount++;
        }
    }
}
