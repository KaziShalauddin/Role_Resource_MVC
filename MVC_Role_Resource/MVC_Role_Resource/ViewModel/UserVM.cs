using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Role_Resource.Models.RoleResource;

namespace MVC_Role_Resource.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }
        public string LogInName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        public int RoleId { get; set; }
        public SecRole Role { get; set; }

        public List<SecRole> SecRoles { get; set; }
    }
}