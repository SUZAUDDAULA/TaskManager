using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.Master
{
    public class Occupation:Base
    {
        [Required]
        [Column(TypeName = "NVARCHAR(180)")]
        public string occupationName { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string occupationShortName { get; set; }
        public int? shortOrder { get; set; }
    }
}
