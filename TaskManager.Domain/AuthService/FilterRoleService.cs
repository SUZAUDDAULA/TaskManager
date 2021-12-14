using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.DAL;
using TaskManager.DAL.Models.Auth;
using TaskManager.Domain.JWT_Service.Interfaces;

namespace TaskManager.Domain.JWT_Service
{
    public class FilterRoleService: IFilterRoleService
    {

        private readonly TMDbContext _context;

        public FilterRoleService(TMDbContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<FileterRoleByUserViewModel>> GetFilterRoleByUserId(string id)
        {
            var result = await (from r in _context.Roles
                                join AR in (from a in _context.UserRoles
                                            where a.UserId == id
                                            select a) on r.Id equals AR.RoleId into aar
                                from ccr in aar.DefaultIfEmpty()
                                select new FileterRoleByUserViewModel
                                {
                                    roleId = r.Id,
                                    roleName = r.Name,
                                    arRoleId = ccr.RoleId
                                }).AsNoTracking().ToListAsync();

            return result;

        }
    }
}
