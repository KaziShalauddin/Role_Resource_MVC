using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecUserRole
    {
        public int Id { get; set; }
        public int SecUserId { get; set; }
        public SecUser SecUser { get; set; }
        public int SecRoleId { get; set; }
        public SecRole SecRole { get; set; }
       

        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDateTime { get; set; }

    }
}