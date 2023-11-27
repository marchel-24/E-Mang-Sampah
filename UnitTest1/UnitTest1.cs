using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using E_Mang_Sampah.Model;
using E_Mang_Sampah.Services.Authentication;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmangSampahModelContainer1 db = new EmangSampahModelContainer1();
            ValidationManager validationManager = new ValidationManager(db);

            string mockUsername = "EdoBagus";
            string mockPassword = "123";
            Assert.IsTrue(validationManager.Validate(mockUsername, mockPassword));
        }
    }
}
