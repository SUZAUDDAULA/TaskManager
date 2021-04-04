using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class Division : Base
    {
        public int? countryId { get; set; }
        public Country country { get; set; }
        
        [Column(TypeName = "NVARCHAR(20)")]
        public string divisionCode { get; set; }        
        [Column(TypeName = "NVARCHAR(120)")]
        public string divisionName { get; set; }
        public string divisionNameBn { get; set; }
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
