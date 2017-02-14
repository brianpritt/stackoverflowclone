using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowClone.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string QuestionDetail { get; set; }
        public int Votes { get; set; }
        public virtual ApplicationUser SubmittingUser { get; set; }
        //public virtual List<Response> Responses { get; set; }
    }
}