using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Mang_Sampah.Model
{
    public partial class UserAccount
    {
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
