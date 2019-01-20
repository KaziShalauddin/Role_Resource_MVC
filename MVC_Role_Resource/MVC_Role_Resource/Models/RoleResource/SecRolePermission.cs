using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecRolePermission
    {
        public int Id { get; set; }
        public int SecResourceId { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }


        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModificationDateTime { get; set; }
    }
}