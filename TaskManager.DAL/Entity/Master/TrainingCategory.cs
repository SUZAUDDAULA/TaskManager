using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.Master
{
    public class TrainingCategory:Base
    {
        [Required]
        [Column(TypeName = "NVARCHAR(220)")]
        public string trainingCategoryName { get; set; }
        [Column(TypeName = "NVARCHAR(220)")]
        public string trainingCategoryNameBn { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string trainingCategoryShortName { get; set; }
    }
}
