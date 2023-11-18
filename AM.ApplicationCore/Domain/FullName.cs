using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "3 caracteres au minimum")]
        [MaxLength(25, ErrorMessage = "25 caracteres au maximum")]
        public string FirstName { get; set; } //="abc" val par defaut
        public string LastName { get; set; }
    }
}
