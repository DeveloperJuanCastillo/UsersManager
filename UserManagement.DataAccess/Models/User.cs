using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; } = string.Empty; // Debe tener un solo carácter
    }
}
