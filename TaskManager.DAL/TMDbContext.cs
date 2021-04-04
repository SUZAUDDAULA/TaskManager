using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Entity;
using TaskManager.DAL.Entity.Auth;
using TaskManager.DAL.Entity.Master;

namespace TaskManager.DAL
{
    public class TMDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TMDbContext(DbContextOptions<TMDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        #region Auth
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserAccessPage> UserAccessPages { get; set; }
        public DbSet<ModuleAccessPage> ModuleAccessPages { get; set; }
        public DbSet<TMModule> TMModules { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        #endregion

        #region Master Data
        public DbSet<Project> Projects { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<UnionWard> UnionWards { get; set; }
        public DbSet<ZoneCircle> ZoneCircles { get; set; }
        public DbSet<RangeMetro> RangeMetros { get; set; }
        public DbSet<DivisionDistrict> DivisionDistricts { get; set; }
        public DbSet<PoliceThana> PoliceThanas { get; set; }
        public DbSet<ManufactureInfo> ManufactureInfos { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationStatus> OccupationStatuses { get; set; }
        public DbSet<PoliticalParty> PoliticalParties { get; set; }
        public DbSet<SpecialPrivilege> SpecialPrivileges { get; set; }
        public DbSet<TrainingCategory> TrainingCategories { get; set; }
        public DbSet<TrainingInstitute> TrainingInstitutes { get; set; }
        #endregion

        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }

            }
        }
        #endregion

    }
}
