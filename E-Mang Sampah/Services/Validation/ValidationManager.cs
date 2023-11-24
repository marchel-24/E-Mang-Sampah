using E_Mang_Sampah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Services.Authentication
{
    internal class ValidationManager
    {
        private EmangSampahEntities db;

        public ValidationManager(EmangSampahEntities db)
        {
            this.db = db;
        }

        public bool Validate(string username, string password)
        {
            return db.Accounts.Where(r => r.Username == username && r.Password == password).Count() > 0;
        }
    }
}
