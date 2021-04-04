using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class District : Base
    {
        public int divisionId { get; set; }
        public Division division { get; set; }
       
        [Column(TypeName = "NVARCHAR(20)")]
        public string districtCode { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string districtName { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string districtNameBn { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string shortName { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string isActive { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string latitude { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string longitude { get; set; }
       
    }
}
