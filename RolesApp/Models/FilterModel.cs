using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolesApp.Models
{
    public class FilterModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList select { get; set; }
        public string Name { get; set; }
    }
}
