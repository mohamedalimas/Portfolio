using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Owner : Entity
    {
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? AvatarUrl { get; set; }
        public Adress? Adress { get; set; }
    }
}
