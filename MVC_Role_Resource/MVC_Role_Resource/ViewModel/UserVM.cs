using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_Role_Resource.Models.RoleResource;

namespace MVC_Role_Resource.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }
        [Display(Name = "Log In Name")]
        public string LogInName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public SecRole Role { get; set; }

        public List<SecRole> SecRoles { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDateTime { get; set; }
    }
}