using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowClone.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        public string ResponseDetail { get; set; }
        public int Votes { get; set; }
        public virtual ApplicationUser SubmittingUser { get; set; }
        public virtual Question Question { get; set; }
    }
}