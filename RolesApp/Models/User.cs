using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolesApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string Color { get; set; }
        public string Pot { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
