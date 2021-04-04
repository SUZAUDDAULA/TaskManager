using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.Master
{
    public class PoliticalParty:Base
    {
        [Required]
        [Column(TypeName = "NVARCHAR(260)")]
        public string name { get; set; }
        [Column(TypeName = "NVARCHAR(260)")]
        public string nameBn { get; set; }
    }
}
