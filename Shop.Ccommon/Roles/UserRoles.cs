using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Ccommon.Roles
{
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string Operator = "Operator";
        public const string Customer = "Customer";
    }

  
}

namespace Shop.Ccommon.Purches
{ 
   public class MethodOfPost
    {
        public const string Mail = "پست";
        public const string ExpressMail = "پست پیشتاز";
    }

    public class States
    {
        public const string KhorasanRazavi  = "خراسان رضوی";
        public const string KhorasanJonooby = "خراسان جنوبی";
        public const string KhorasanShomaly = "خراسان شمالی";
        public const string Tehran = "تهران";
    }
}
