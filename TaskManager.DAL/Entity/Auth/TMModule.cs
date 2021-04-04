namespace TaskManager.DAL.Entity.Auth
{
    public class TMModule:Base
    {
        public string moduleName { get; set; }

        public string moduleNameBN { get; set; }

        public int? shortOrder { get; set; }

        public string isTeam { get; set; }
    }
}
