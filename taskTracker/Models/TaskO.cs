using System;
using System.Collections.Generic;
using System.Text;

namespace taskTracker.Models
{
    public class TaskO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set;}
    }

}
