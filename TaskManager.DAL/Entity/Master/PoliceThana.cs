using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class PoliceThana : Base
    {
        public int? rangeMetroId { get; set; }
        public RangeMetro rangeMetro { get; set; }

        public int? divisionDistrictId { get; set; }
        public DivisionDistrict divisionDistrict { get; set; }

        public int? zoneCircleId { get; set; }
        public ZoneCircle zoneCircle { get; set; }

        public int? upazillaId { get; set; }
        public Thana upazilla { get; set; }

        [Column(TypeName = "NVARCHAR(350)")]
        public string policeThanaName { get; set; }
        [Column(TypeName = "NVARCHAR(350)")]
        public string policeThanaNameBn { get; set; }        
        [Column(TypeName = "NVARCHAR(10)")]
        public string isActive { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string isReportable { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string latitude { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string longitude { get; set; }
    }
}
