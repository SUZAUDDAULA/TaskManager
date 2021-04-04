using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.DAL.Entity.Master
{
    public class ManufactureInfo:Base
    {
        [Column(TypeName = "NVARCHAR(160)")]
        public string ManufactureName { get; set; }
        [Column(TypeName = "NVARCHAR(160)")]
        public string OrganizationName { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string Origin { get; set; }
    }
}
