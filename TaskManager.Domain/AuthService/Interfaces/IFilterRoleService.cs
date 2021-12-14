using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.DAL.Models.Auth;

namespace TaskManager.Domain.JWT_Service.Interfaces
{
    public interface IFilterRoleService
    {
        Task<IEnumerable<FileterRoleByUserViewModel>> GetFilterRoleByUserId(string id);
    }
}
