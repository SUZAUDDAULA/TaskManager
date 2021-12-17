using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.TaskData
{
    public class ClientLocation:Base
    {
        [Column(TypeName = "NVARCHAR(300)")]
        public string clientLocationName { get; set; }
    }
}
