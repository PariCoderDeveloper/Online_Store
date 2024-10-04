using Shop.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}
