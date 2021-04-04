using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Entity.Auth
{
    public class ModuleAccessPage:Base
    {
        public int? eRPModuleId { get; set; }
        public TMModule eRPModule { get; set; }
        
        public string applicationRoleId { get; set; }
        public ApplicationRole applicationRole { get; set; }
    }
}
