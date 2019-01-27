using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecRolePermission
    {
        public int Id { get; set; }
        public int SecResourcePermissionId { get; set; }
        public SecResourcePermission SecResourcePermission { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }


       
    }
}