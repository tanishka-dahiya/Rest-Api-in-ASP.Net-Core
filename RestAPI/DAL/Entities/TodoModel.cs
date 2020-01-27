using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class TodoModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string TimeLeft { get; set; } = "None";
        public int IsCompleted { get; set; } = 0;
        public int IsDeleted { get; set; } = 0;
        public int IsExpired { get; set; } = 0;



    }
}
