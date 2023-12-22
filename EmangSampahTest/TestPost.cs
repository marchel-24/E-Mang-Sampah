using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using E_Mang_Sampah.Model;

namespace EmangSampahTest
{
    [TestClass]
    public class TestPost
    {
        private Posts post = new Posts
        {
            PostsId = 0,
            Content = null,
            LikesCount = 0,
            UploadTime = default,
            AccountId = 0,
            Image = new byte[]
            {
            },
            Account = null
        };

        [TestMethod]
        public void addLikes_LikesShouldIncrease()
        {
            bool isLiked = true;
            int initialLikesCount = post.LikesCount;
            post.AddLikes(isLiked);
            
            Assert.AreEqual(initialLikesCount + 1, post.LikesCount);
        }

        [TestMethod]
        public void addLikes_LikesShouldDecrease()
        {
            bool isLiked = false;
            int initialLikesCount = post.LikesCount;
            post.AddLikes(isLiked);

            Assert.AreEqual(initialLikesCount - 1, post.LikesCount);
        }


    }
}
