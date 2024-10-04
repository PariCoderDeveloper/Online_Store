using FluentValidation;
using Shop.Domain.Commen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string Fullname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }

}
