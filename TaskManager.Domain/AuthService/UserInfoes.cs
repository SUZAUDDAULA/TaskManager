using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.DAL;
using TaskManager.DAL.Entity;
using TaskManager.DAL.Entity.Auth;
using TaskManager.DAL.Models.Auth;
using TaskManager.Domain.AuthService.Interfaces;

namespace TaskManager.Domain.AuthService
{
    public class UserInfoes: IUserInfoes
    {
        private readonly TMDbContext _context;
        public UserInfoes(TMDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserInfoByUser(string userName)
        {
            return await _context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserInfoByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserInfoList()
        {
            var result =await (from a in _context.Users
                         select new AspNetUsersViewModel
                         {
                             UserName = a.UserName,
                             Email = a.Email
                         }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<TMModule>> GetAllFAMSModule()
        {
            return await _context.TMModules.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteRoleById(string Id)
        {
            _context.Roles.Remove(_context.Roles.Where(x => x.Id == Id).First());
            return 1 == await _context.SaveChangesAsync();
        }

    }
}
