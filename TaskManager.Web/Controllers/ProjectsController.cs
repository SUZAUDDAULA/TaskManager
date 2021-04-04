using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DAL.Entity.Master;
using TaskManager.DAL.Models.MasterData;
using TaskManager.Domain.RepositoryService.Interfaces;

namespace TaskManager.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IRepository<Project> _projectRepo;

        public ProjectsController(IRepository<Project> projectRepo)
        {
            _projectRepo = projectRepo;
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
        public IActionResult SaveProject([FromBody]ProjectModel model)
        {
            try
            {
                Project project = new Project
                {
                    Id = (int)model.Id,
                    projectCode=model.projectCode,
                    projectName = model.projectName,
                    startDate = model.startDate,
                    teamSize = model.teamSize
                };
                _projectRepo.Insert(project);
                return Json(project);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPut]
        [Route("api/masterData/UpdateProject")]
        public IActionResult UpdateProject([FromBody] ProjectModel model)
        {
            try
            {
                Project project = new Project
                {
                    Id = (int)model.Id,
                    projectCode=model.projectCode,
                    projectName = model.projectName,
                    startDate = model.startDate,
                    teamSize = model.teamSize
                };
                _projectRepo.Update(project);
                return Json(project);
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

    }
}
