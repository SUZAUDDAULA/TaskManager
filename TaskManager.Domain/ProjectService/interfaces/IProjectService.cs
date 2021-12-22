using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Entity.TaskData;
using TaskManager.DAL.Models.MasterData;

namespace TaskManager.Domain.ProjectService.interfaces
{
    public interface IProjectService
    {
        Task<int> SaveProject(Project project);
        Task<ProjectModel> GetProjectDetailsInfoById(int projectId);
        Task<Project> GetProjectDetailsInfoByCode(string code);
        Task<IEnumerable<ProjectModel>> GetAllProjectListWithClientLocation();
        Task<IEnumerable<ProjectModel>> GetProjectListWithFiltering(string searchBy, string searchText);
        Task<IEnumerable<ClientLocation>> GetClientLocationList();
    }
}
