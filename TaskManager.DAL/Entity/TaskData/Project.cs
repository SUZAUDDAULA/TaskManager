using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.TaskData
{
    public class Project:Base
    {
        [Column(TypeName = "NVARCHAR(200)")]
        public string projectName { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string projectCode { get; set; }
        public DateTime? startDate { get; set; }
        public int? teamSize { get; set; }
        public int? clientLocationId { get; set; }
        public ClientLocation clientLocation { get; set; }
    }
}
