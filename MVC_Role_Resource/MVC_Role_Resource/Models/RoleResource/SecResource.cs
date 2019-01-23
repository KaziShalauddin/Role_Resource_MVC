using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models.RoleResource
{
    public class SecResource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MenuName { get; set; }
        public string DisplayName { get; set; }
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public int Level { get; set; }
        public string ActionUrl { get; set; }
        public bool Status { get; set; }
        
        public int CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDateTime { get; set; }
    }
}