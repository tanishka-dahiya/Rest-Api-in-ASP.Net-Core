using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHARED.ViewModals
{
    public class Task
    {
       
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string TimeLeft { get; set; }
        public int IsCompleted { get; set; } 
        public int IsDeleted { get; set; }
        public int IsExpired { get; set; } 
    }
}
