using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class DivisionDistrict : Base
    {
        public int? rangeMetroId { get; set; }
        public RangeMetro rangeMetro { get; set; }
        
        [Column(TypeName = "NVARCHAR(350)")]
        public string divisionDistrictName { get; set; }
        [Column(TypeName = "NVARCHAR(350)")]
        public string divisionDistrictNameBn { get; set; }        
        [Column(TypeName = "NVARCHAR(10)")]
        public string isActive { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string latitude { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string longitude { get; set; }
    }
}
