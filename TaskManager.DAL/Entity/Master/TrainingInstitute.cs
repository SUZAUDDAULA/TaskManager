using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.Master
{
    public class TrainingInstitute:Base
    {
        [Required]
        [Column(TypeName = "NVARCHAR(220)")]
        public string trainingInstituteName { get; set; }
        [Column(TypeName = "NVARCHAR(220)")]
        public string trainingInstituteNameBn { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string trainingInstituteShortName { get; set; }
    }
}
