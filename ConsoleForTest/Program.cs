using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mang_Sampah;
using E_Mang_Sampah.Model;

namespace ConsoleForTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
            //UserAccount user = new UserAccount();
            //user.Username = "Test4";
            //user.Password = "123";
            //user.FirstName = "Test9";
            //user.LastName = "Test10";

            //Posts posts = new Posts();
            //posts.Account = db.Accounts.Find(3);
            //posts.Content = 12345;
            //posts.LikesCount = "testLagiBos";
            //posts.UploadTime = DateTime.Now;
            //db.Accounts.Add(user);
            //db.Posts.Add(posts);
            //db.SaveChanges();

            //var account = db.Accounts.ToList().First(r => r.Username == "EdoBagus");
            ////foreach (var acc in account)
            //{
            //    Console.WriteLine(acc.AccountId);
            //    Console.WriteLine(acc.Username);
            //    Console.WriteLine(acc.Password);
            //    Console.WriteLine(acc);
            //    Console.WriteLine();
            //    Console.ReadLine();
            //}

            //var account = db.Accounts.OfType<UserAccount>().w;
            //Console.WriteLine(account);
            //Console.ReadLine();

            //Order order = new Order();
            //UserAccount account = db.Accounts.OfType<UserAccount>().First(r => r.FirstName == "Edo");
            PartnerAccount partnerAccount = db.Accounts.OfType<PartnerAccount>().First(r => r.CompanyName == "TrashCorp");
            //order.UserAccount = account;
            //order.PartnerAccount = partnerAccount;
            //order.OrderReqTime = DateTime.Now;

            //db.Orders.Add(order);
            //db.SaveChanges();
            //Console.ReadLine();

            var order = partnerAccount.Orders.First(r => r.OrderId == 2);
            Console.WriteLine(order.UserAccount.FirstName);
            Console.ReadLine();

            //Posts post = new Posts();
            //post.addLikes();
        }
    }
}
