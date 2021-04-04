using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Entity.Auth;

namespace TaskManager.DAL.Models.Auth
{
    public class ApplicationRoleViewModel
    {
        public string RoleId { get; set; }
        public string PreRoleId { get; set; }
        public string[] roleIdList { get; set; }

        public string userId { get; set; }

        public string userName { get; set; }
        public string EuserName { get; set; }

        public string RoleName { get; set; }

        public int? moduleId { get; set; }

        public string description { get; set; }

        public string moduleName { get; set; }
        public IEnumerable<TMModule> fAMSModules { get; set; }
        public IEnumerable<ApplicationRoleViewModel> roleViewModels { get; set; }
    }
}
