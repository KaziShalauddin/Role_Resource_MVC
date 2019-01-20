using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDateTime { get; set; }

    }
}