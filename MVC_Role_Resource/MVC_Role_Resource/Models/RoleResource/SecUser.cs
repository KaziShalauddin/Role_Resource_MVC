using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecUser
    {
        public int Id { get; set; }
        public string LogInName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDateTime { get; set; }

        public int? RoleId { get; set; }
        public SecRole Role { get; set; }

    }
}