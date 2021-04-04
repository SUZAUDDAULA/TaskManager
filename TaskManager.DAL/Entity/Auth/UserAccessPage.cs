namespace TaskManager.DAL.Entity.Auth
{
    public class UserAccessPage:Base
    {
        public int? navbarId { get; set; }
        public Navbar navbar { get; set; }

        public int? isAccess { get; set; }

        public string applicationRoleId { get; set; }
        public ApplicationRole applicationRole { get; set; }
    }
}
