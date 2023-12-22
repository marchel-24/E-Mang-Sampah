using E_Mang_Sampah.Model;

namespace EmangSampahTest
{
    [TestClass]
    public class TestUserAccount
    {
        UserAccount account = new UserAccount
        {
            Username = "Edo",
            Password = "123",
            Latitude = 10,
            Longitude = 10,
            Address = "Semarang",
            FirstName = "Edo",
            LastName = "Bagus",
            Xp = 0
        };

        [TestMethod]
        public void GetFullName_ShouldReturnFullName()
        {
            string fullName = account.GetFullName();
            Assert.AreEqual("Edo Bagus", fullName);
        }

        [TestMethod]
        public void AddXp_ShouldIncreaseXp()
        {
            int initialXp = account.Xp;
            account.AddXp(50);

            Assert.AreEqual(initialXp + 50, account.Xp);
        }
    }
}