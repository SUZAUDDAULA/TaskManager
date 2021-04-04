using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models.MasterData
{
    public class ProjectModel
    {
        public int? Id { get; set; }
        public string projectName { get; set; }
        public string projectCode { get; set; }
        public DateTime? startDate { get; set; }
        public int? teamSize { get; set; }
    }
}
