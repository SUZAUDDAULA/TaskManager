using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class UnionWard : Base
    {
        public int thanaId { get; set; }
        public Thana thana { get; set; }

        public int? districtsId { get; set; }
        public District districts { get; set; }

        [Column(TypeName ="NVARCHAR(20)")]
        public string unionCode { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string unionName { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string unionNameBn { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string shortName { get; set; }        
        [Column(TypeName = "NVARCHAR(10)")]
        public string isActive { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string latitude { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string longitude { get; set; }

    }
}
