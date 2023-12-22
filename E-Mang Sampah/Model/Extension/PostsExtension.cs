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
        /// Adds or removes a like to the post based on the specified value.
        /// </summary>
        /// <param name="isLiked">A boolean value indicating whether to add or remove a like.
        /// If <c>true</c>, a like is added; if <c>false</c>, a like is removed.</param>
        public void AddLikes(bool isLiked)
        {
            if (isLiked)
            {
                LikesCount++;
            }
            else
            {
                LikesCount--;
            }
        }
    }
}
