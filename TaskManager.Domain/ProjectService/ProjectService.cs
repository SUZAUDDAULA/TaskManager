using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL;
using TaskManager.DAL.Entity.TaskData;
using TaskManager.DAL.Models.MasterData;
using TaskManager.Domain.ProjectService.interfaces;

namespace TaskManager.Domain.ProjectService
{
    public class ProjectService:IProjectService
    {
        private readonly TMDbContext _context;

        public ProjectService(TMDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveProject(Project project)
        {
            try
            {
                if (project.Id != 0)
                {
                    _context.Projects.Update(project);
                }
                else
                {
                    _context.Projects.Add(project);
                }

                await _context.SaveChangesAsync();
                return project.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProjectModel> GetProjectDetailsInfoById(int projectId)
        {
            var result = await _context.Projects.Where(x=>x.Id==projectId).Include(x => x.clientLocation)
                .Select(x => new ProjectModel
                {
                    Id = x.Id,
                    projectName = x.projectName,
                    projectCode = x.projectCode,
                    startDate = Convert.ToDateTime(x.startDate).ToString("dd-MM-yyyy"),
                    teamSize = x.teamSize,
                    clientLocationId = x.clientLocationId,
                    clientLocation = x.clientLocation
                }).FirstOrDefaultAsync();

            return result;
        }
        public async Task<IEnumerable<ProjectModel>> GetAllProjectListWithClientLocation()
        {
            var result = await _context.Projects.Include(x=>x.clientLocation)
                .Select(x=> new ProjectModel 
                {
                    Id=x.Id,
                    projectName=x.projectName,
                    projectCode=x.projectCode,
                    startDate=Convert.ToDateTime(x.startDate).ToString("dd-MM-yyyy"),
                    teamSize=x.teamSize,
                    clientLocationId=x.clientLocationId,
                    clientLocation=x.clientLocation
                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectListWithFiltering(string searchBy, string searchText)
        {
            List<ProjectModel> lstProject = new List<ProjectModel>();
            if (searchBy == "projectCode")
            {
                lstProject = await (from p in _context.Projects
                                    join c in _context.ClientLocations on p.clientLocationId equals c.Id
                                    where p.projectCode.Contains(searchText)
                                    select new ProjectModel
                                    {
                                        Id = p.Id,
                                        projectName = p.projectName,
                                        projectCode = p.projectCode,
                                        startDate = Convert.ToDateTime(p.startDate).ToString("dd-MM-yyyy"),
                                        teamSize = p.teamSize,
                                        clientLocationId = p.clientLocationId,
                                        clientLocation = p.clientLocation
                                    }).ToListAsync();
            }
            else if (searchBy == "ProjectName")
            {
                lstProject = await (from p in _context.Projects
                                    join c in _context.ClientLocations on p.clientLocationId equals c.Id
                                    where p.projectName.Contains(searchText)
                                    select new ProjectModel
                                    {
                                        Id = p.Id,
                                        projectName = p.projectName,
                                        projectCode = p.projectCode,
                                        startDate = Convert.ToDateTime(p.startDate).ToString("dd-MM-yyyy"),
                                        teamSize = p.teamSize,
                                        clientLocationId = p.clientLocationId,
                                        clientLocation = p.clientLocation
                                    }).ToListAsync();
            }
            else if (searchBy == "StartDate")
            {
                lstProject = await (from p in _context.Projects
                                    join c in _context.ClientLocations on p.clientLocationId equals c.Id
                                    where p.startDate.ToString().Contains(searchText)
                                    select new ProjectModel
                                    {
                                        Id = p.Id,
                                        projectName = p.projectName,
                                        projectCode = p.projectCode,
                                        startDate = Convert.ToDateTime(p.startDate).ToString("dd-MM-yyyy"),
                                        teamSize = p.teamSize,
                                        clientLocationId = p.clientLocationId,
                                        clientLocation = p.clientLocation
                                    }).ToListAsync();
            }
            else if (searchBy == "TeamSize")
            {
                lstProject = await (from p in _context.Projects
                                    join c in _context.ClientLocations on p.clientLocationId equals c.Id
                                    where p.teamSize.ToString().Contains(searchText)
                                    select new ProjectModel
                                    {
                                        Id = p.Id,
                                        projectName = p.projectName,
                                        projectCode = p.projectCode,
                                        startDate = Convert.ToDateTime(p.startDate).ToString("dd-MM-yyyy"),
                                        teamSize = p.teamSize,
                                        clientLocationId = p.clientLocationId,
                                        clientLocation = p.clientLocation
                                    }).ToListAsync();
            }
            else
            {
                lstProject = await (from p in _context.Projects
                                    join c in _context.ClientLocations on p.clientLocationId equals c.Id
                                    select new ProjectModel
                                    {
                                        Id = p.Id,
                                        projectName = p.projectName,
                                        projectCode = p.projectCode,
                                        startDate = Convert.ToDateTime(p.startDate).ToString("dd-MM-yyyy"),
                                        teamSize = p.teamSize,
                                        clientLocationId = p.clientLocationId,
                                        clientLocation = p.clientLocation
                                    }).ToListAsync();
            }


            return lstProject;
        }

        public async Task<IEnumerable<ClientLocation>> GetClientLocationList()
        {
            var result = await _context.ClientLocations.ToListAsync();
            return result;
        }

    }
}
