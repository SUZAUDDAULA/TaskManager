using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity.Master
{
    public class Skill:Base
    {
        public string skillName { get; set; }
        public string skillLevel { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
