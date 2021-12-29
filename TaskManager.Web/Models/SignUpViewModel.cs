using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.DAL.Entity.Master;

namespace TaskManager.Web.Models
{
    public class SignUpViewModel
    {
        public PersonFullName personFullName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string dateOfBirth { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string countryId { get; set; }
        public bool receiveNewsLetters { get; set; }
        public List<Skill> skills { get; set; }
    }

    public class PersonFullName
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
