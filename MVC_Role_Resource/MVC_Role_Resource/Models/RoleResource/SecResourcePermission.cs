using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecResourcePermission
    {
        public int Id { get; set; }

        public int SecRoleId { get; set; }
        public SecRole SecRole { get; set; }
        public int SecResourceId { get; set; }
        public SecResource SecResource { get; set; }

        public string FileName { get; set; }
        public string MenuName { get; set; }
        public string DisplayName { get; set; }
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public int Level { get; set; }
        public string ActionUrl { get; set; }
        public string Status { get; set; }


        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDateTime { get; set; }
    }
}