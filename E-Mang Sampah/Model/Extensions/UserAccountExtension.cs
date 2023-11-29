using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Model
{
    public partial class UserAccount : Account
    {
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
