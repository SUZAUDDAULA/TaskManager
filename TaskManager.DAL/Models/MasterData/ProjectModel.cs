using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Entity.TaskData;

namespace TaskManager.DAL.Models.MasterData
{
    public class ProjectModel
    {
        public int? Id { get; set; }
        public string projectName { get; set; }
        public string projectCode { get; set; }
        public string startDate { get; set; }
        public int? teamSize { get; set; }
        public int? clientLocationId { get; set; }
        public ClientLocation clientLocation { get; set; }
    }
}
