using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace StackOverflowClone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Question> Questions { get; set; }
        public virtual List<Response> Responses { get; set; }
    }
}