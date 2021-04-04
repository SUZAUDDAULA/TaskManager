using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Entity;
using TaskManager.DAL.Entity.Auth;
using TaskManager.DAL.Models.Auth;

namespace TaskManager.Domain.AuthService.Interfaces
{
    public interface IUserInfoes
    {
        Task<ApplicationUser> GetUserInfoByUser(string userName);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList();
        Task<IEnumerable<TMModule>> GetAllFAMSModule();
        Task<bool> DeleteRoleById(string Id);
    }
}
