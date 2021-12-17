using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DAL.Entity.Master;
using TaskManager.DAL.Entity.TaskData;
using TaskManager.DAL.Models.MasterData;
using TaskManager.Domain.ProjectService.interfaces;
using TaskManager.Domain.RepositoryService.Interfaces;

namespace TaskManager.Web.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IRepository<Project> _projectRepo;
        private readonly IProjectService _projectService;

        public ProjectsController(IRepository<Project> projectRepo, IProjectService projectService)
        {
            _projectRepo = projectRepo;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/masterData/project")]
        public IActionResult GetAllProjectInfo()
        {
            var projects = _projectRepo.GetAll();
            return Json(projects);
        }

        [HttpPost]
        [Route("api/masterData/SaveProject")]
        public async Task<IActionResult> SaveProject([FromBody]ProjectModel model)
        {
            try
            {
                Project project = new Project
                {
                    Id = (int)model.Id,
                    projectCode=model.projectCode,
                    projectName = model.projectName,
                    startDate = Convert.ToDateTime(model.startDate),
                    teamSize = model.teamSize,
                    clientLocationId=model.clientLocationId
                };
                await _projectService.SaveProject(project);
                return Json(project);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPut]
        [Route("api/masterData/UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectModel model)
        {
            try
            {
                Project project = new Project
                {
                    Id = (int)model.Id,
                    projectCode=model.projectCode,
                    projectName = model.projectName,
                    startDate = Convert.ToDateTime(model.startDate),
                    teamSize = model.teamSize
                };
                _projectRepo.Update(project);
                var projectInfo = await _projectService.GetProjectDetailsInfoById((int)model.Id);
                return Json(projectInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete]
        [Route("api/masterData/DeleteProject/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                var project = _projectRepo.Get(projectId);
                _projectRepo.Delete(project);
                return Json(projectId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("api/projectss/Search/{searchBy}/{searchText}")]
        public async Task<IEnumerable<ProjectModel>> Search(string searchBy,string searchText)
        {
            try
            {
                IEnumerable<ProjectModel> projects = null;
                //if(searchBy== "ProjectCode")
                //    projects = _projectRepo.GetAll().Where(x => x.projectCode.ToString().Contains(searchText)).ToList();
                //else if (searchBy=="ProjectName")
                //    projects= _projectRepo.GetAll().Where(x => x.projectName.ToString().Contains(searchText)).ToList();
                //else if(searchBy=="StartDate")
                //    projects = _projectRepo.GetAll().Where(x => x.startDate.ToString().Contains(searchText)).ToList();
                //else if (searchBy == "TeamSize")
                //    projects = _projectRepo.GetAll().Where(x => x.teamSize.ToString().Contains(searchText)).ToList();
                projects = await _projectService.GetProjectListWithFiltering(searchBy,searchText);
                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
