using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Auth
{
    public class Navbar:Base
    {
        [Column(TypeName = "nvarchar(250)")]
        public string nameOptionBangla { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string nameOption { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string controller { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string action { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string area { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string imageClass { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string activeLi { get; set; }

        public bool status { get; set; }

        public int parentID { get; set; }

        public int? isParent { get; set; }

        public int? displayOrder { get; set; }

        public int? moduleId { get; set; }
        public TMModule module { get; set; }

        [NotMapped]
        public string moduleName { get; set; }
        [NotMapped]
        public string parentName { get; set; }
        [NotMapped]
        public string bandName { get; set; }
    }
}
