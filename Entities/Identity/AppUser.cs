using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Identity
{
    public class AppUser:IdentityUser<int>
    {      
        public List<Exam> Exams { get; set; }
    }
}
