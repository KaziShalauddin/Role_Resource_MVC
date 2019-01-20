using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC_Role_Resource.Models.RoleResource;

namespace MVC_Role_Resource.Models
{
    public class RoleResourceDBContext:DbContext
    {
       public DbSet<Student> Students { get; set; }

       public DbSet<SecUser> SecUsers { get; set; }
       public DbSet<SecRole> SecRoles { get; set; }
       public DbSet<SecUserRole> SecUserRoles { get; set; }
       public DbSet<SecResource> SecResources { get; set; }
        public DbSet<SecRolePermission> SecRolePermissions { get; set; }
        public DbSet<SecResourcePermission> SecResourcePermissions { get; set; }
       
    }
}